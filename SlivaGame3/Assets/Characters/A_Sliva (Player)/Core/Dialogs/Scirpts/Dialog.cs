using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace DialogSystem
{
    public class Dialog : MonoBehaviour
    {
        private DialogsController _dialogController;

        [SerializeField] private List<Branch> _branchesList = new List<Branch>();
        [SerializeField] private List<Choice> _choicesList = new List<Choice>();

        private Branch _currentBranch;
        private int _step = 0;

        public List<Branch> BranchesList { get => _branchesList; }
        public List<Choice> ChoicesList { get => _choicesList; }
        public Branch CurrentBranch { get => _currentBranch; }
        public int Step { get => _step; }

        private void Start()
        {
            _dialogController = FindObjectOfType<DialogsController>();
            this.enabled = false;
        }

        private void Update()
        {
            CheckTouch();
        }

        private void CheckTouch()
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.touchCount > 0)
            {
                if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (_dialogController.DialogTab.activeInHierarchy == true)
                    {
                        CallDialog();
                    }
                }
            }
        }

        public void CallDialog()
        {
            if (_dialogController.MightSetDialog == true)
            {
                if (_step > 0)
                {
                    _currentBranch.Phrases[_step - 1].TriggeringAfterActions();
                }

                if (_step < _currentBranch.Phrases.Count)
                {
                    _dialogController.SetPhrase(_currentBranch.Phrases[_step].Speaker, _currentBranch.Phrases[_step].PhraseText, _currentBranch.Phrases[_step].VoiceActing, _currentBranch.Phrases[_step]); ;
                    _step++;
                }
            }

            else if (_dialogController.MightSetDialog == false)
            {
                _dialogController.SkipPhrase();
            }
        }

        public void SetCurrentBranch(int branchNumber)
        {
            if (_dialogController.DialogText.gameObject.activeInHierarchy == false)
            {
                for (int i = 0; i < _dialogController.AnswerButtons.Length; i++)
                {
                    _dialogController.AnswerButtons[i].gameObject.SetActive(false);
                }

                _dialogController.DialogText.gameObject.SetActive(true);
                _dialogController.MightSetDialog = true;
            }

            _currentBranch = _branchesList[branchNumber];
            _step = 0;
        }

        public void SetStep(int value)
        {
            _step = value;
        }

        public void OnChoice(int choiceNumber)
        {
            _dialogController.AudioSourceVoiceAction.Stop();

            _dialogController.MightSetDialog = false;
            _dialogController.DialogText.gameObject.SetActive(false);

            for (int i = 0; i < _choicesList[choiceNumber].AnswerTexts.Count; i++)
            {
                _dialogController.AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _choicesList[choiceNumber].AnswerTexts[i];
                _dialogController.AnswerButtons[i].onClick = _choicesList[choiceNumber].AnswerEvents[i];
            }

            for (int i = 0; i < _choicesList[choiceNumber].AnswerTexts.Count; i++)
            {
                _dialogController.AnswerButtons[i].gameObject.SetActive(true);
            }
        }
        public void StartDialog()
        {
            _currentBranch = _branchesList[0];
            _step = 0;

            this.enabled = true;

            _dialogController.StartDialog();

            CallDialog();
        }

        public void EndDialog()
        {
            this.enabled = false;

            _dialogController.EndDialog();
        }


        #region Branches And Phrases
        [System.Serializable]
        public class Phrase
        {
            [SerializeField] private UnityEvent _actionsAfterPhrase;

            [SerializeField] private Character _speaker;

            [TextArea(6, 6)]
            [SerializeField] private string _phraseText;
            [SerializeField] private AudioClip _voiceActing;

            public Character Speaker { get { return _speaker; } }
            public AudioClip VoiceActing { get { return _voiceActing; } }
            public string PhraseText { get { return _phraseText; } }

            public void TriggeringAfterActions()
            {
                _actionsAfterPhrase?.Invoke();
            }

            public void SetSpeaker(Character character)
            {
                _speaker = character;
            }

            public void SetPhraseText(string text)
            {
                _phraseText = text;
            }

            public void SetVoiceActing(AudioClip voiceActing)
            {
                _voiceActing = voiceActing;
            }
        }

        [System.Serializable]
        public struct Branch
        {
            [SerializeField] private List<Phrase> _phrases;

            public List<Phrase> Phrases { get { return _phrases; } }

        }
        #endregion



        #region Choices
        [System.Serializable]
        public struct Choice
        {
            [SerializeField] private List<string> _answerTexts;
            [SerializeField] private List<Button.ButtonClickedEvent> _answerEvents;

            public List<string> AnswerTexts { get => _answerTexts; }
            public List<Button.ButtonClickedEvent> AnswerEvents { get => _answerEvents; }
        }
        #endregion
    }
}