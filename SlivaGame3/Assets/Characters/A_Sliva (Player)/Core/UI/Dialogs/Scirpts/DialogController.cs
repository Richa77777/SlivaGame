using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace DialogSystem
{
    [RequireComponent(typeof(AudioSource))]

    public class DialogController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource1;
        [SerializeField] private AudioSource _audioSource2;

        [SerializeField] private AudioClip _dialogSound;
        [SerializeField] private TextMeshProUGUI _dialogText;
        [SerializeField] private float _timeBtwnChars = 0;

        private bool _mightSetDialog = true;

        public bool MightSetDialog { get { return _mightSetDialog; } }

        private void Awake()
        {
            _audioSource1.clip = _dialogSound;
        }

        private void Start()
        {
            //SetDialog("Слива", "#AA4BC0", "Здравствуйте, меня зовут Сливарио.");
        }

        public void SetDialog(Character speaker, string text, AudioClip voiceAction, Dialog.Phrase phrase)
        {
            StartCoroutine(DialogPlayback(speaker, text, voiceAction, phrase));
        }

        private IEnumerator DialogPlayback(Character speaker, string text, AudioClip voiceAction, Dialog.Phrase phrase)
        {
            _mightSetDialog = false;

            string nameText = speaker.Name;
            string nameColor = speaker.NameColor;
            string name = $"<size={_dialogText.fontSize + 5}><b><color={nameColor}>{nameText}:</color></b></size>";

            string fullText = $"{name} {text}";


            for (int i = name.Length; i <= fullText.Length; i++)
            {
                if (fullText.ToCharArray()[i - 1].ToString() == "<")
                {
                    while (fullText?.ToCharArray()?[i - 1].ToString() != ">")
                    {
                        i++;
                    }
                }

                if (fullText.ToCharArray()[i - 1].ToString() != "<" && fullText.ToCharArray()[i - 1].ToString() != ">")
                {
                    _dialogText.text = fullText.Substring(0, i);

                    if (string.IsNullOrWhiteSpace(fullText.ToCharArray()[i - 1].ToString()) == false)
                    {
                        _audioSource1.Play();
                    }

                    yield return new WaitForSeconds(_timeBtwnChars);
                }
            }

            _mightSetDialog = true;
            phrase.TriggeringAfterActions();
        }
    }
}
