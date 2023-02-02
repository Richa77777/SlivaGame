using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace DialogSystem
{
    [RequireComponent(typeof(AudioSource))]

    public class DialogsController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource1;
        [SerializeField] private AudioSource _audioSource2;

        [SerializeField] private AudioClip _dialogSound;
        [SerializeField] private GameObject _dialogTab;
        [SerializeField] private TextMeshProUGUI _dialogText;
        [SerializeField] private float _timeBtwnChars = 0;
        [SerializeField] private Button[] _answerButtons = new Button[4];

        private bool _mightSetDialog = true;
        private bool _skip = false;

        public GameObject DialogTab { get { return _dialogTab; } }
        public TextMeshProUGUI DialogText { get { return _dialogText; } }
        public Button[] AnswerButtons { get { return _answerButtons; } }
        public bool MightSetDialog { get { return _mightSetDialog; } set { _mightSetDialog = value; } }

        private void Awake()
        {
            _audioSource1.clip = _dialogSound;
        }

        private void Start()
        {
            //SetDialog("Слива", "#AA4BC0", "Здравствуйте, меня зовут Сливарио.");
        }

        public void StartDialog()
        {
            _dialogTab.SetActive(true);
        }

        public void EndDialog()
        {
            _dialogTab.SetActive(false);
            _audioSource1.Stop();
            _audioSource2.Stop();
        }

        public void SkipPhrase()
        {
            _skip = true;
        }

        public void SetPhrase(Character speaker, string text, AudioClip voiceAction, Dialog.Phrase phrase)
        {
            StartCoroutine(PhrasePlayback(speaker, text, voiceAction, phrase));
        }

        private IEnumerator PhrasePlayback(Character speaker, string text, AudioClip voiceAction, Dialog.Phrase phrase)
        {
            _skip = false;
            _mightSetDialog = false;

            string nameText = speaker.Name;
            string nameColor = speaker.NameColor;
            string name = $"<size={_dialogText.fontSize + 5}><b><color={nameColor}>{nameText}:</color></b></size>";

            string fullText = $"{name} {text}";

            if (voiceAction != null)
            {
                _audioSource2.clip = voiceAction;
                _audioSource2.Play();
            }

            else if (voiceAction == null)
            {
                _audioSource2.Stop();
            }

            for (int i = name.Length; i <= fullText.Length; i++)
            {
                if (_skip == false)
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

                else if (_skip == true)
                {
                    _dialogText.text = fullText;
                    break;
                }
            }

            _skip = false;
            _mightSetDialog = true;
        }
    }
}
