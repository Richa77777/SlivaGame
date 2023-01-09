using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace DialogSystem
{
    [RequireComponent(typeof(AudioSource))]

    public class DialogController : MonoBehaviour
    {
        public static DialogController _dialogController;


        [SerializeField] private AudioSource _audioSource1;
        [SerializeField] private AudioSource _audioSource2;

        [SerializeField] private AudioClip _dialogSound;
        [SerializeField] private TextMeshProUGUI _dialogText;
        [SerializeField] private float _timeBtwnChars = 0;

        private bool _mightSetDialog = true;

        public bool MightSetDialog { get { return _mightSetDialog; } }

        private void Awake()
        {
            _dialogController = this;
            _audioSource1.clip = _dialogSound;
        }

        private void Start()
        {
            //SetDialog("�����", "#AA4BC0", "������������, ���� ����� ��������.");
        }

        public void SetDialog(string Name, string Color, string Text, Dialog.Phrase phrase)
        {
            StartCoroutine(DialogPlayback(Name, Color, Text, phrase));
        }

        private IEnumerator DialogPlayback(string Name, string Color, string Text, Dialog.Phrase phrase)
        {
            _mightSetDialog = false;

            string nameText = Name;
            string nameColor = Color;
            string name = $"<size={_dialogText.fontSize + 5}><b><color={nameColor}>{nameText}:</color></b></size>";

            string fullText = $"{name} {Text}";


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
