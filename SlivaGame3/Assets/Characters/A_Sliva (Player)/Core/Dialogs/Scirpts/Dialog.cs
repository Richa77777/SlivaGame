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
        [SerializeField] private List<Choice> _allChoicesList = new List<Choice>();

        private Branch _currentBranch;
        private int _step = 0;

        public List<Branch> BranchesList { get => _branchesList; }
        public List<Choice> AllChoicesList { get => _allChoicesList; }
        public Branch CurrentBranch { get => _currentBranch; }
        public int Step { get => _step; }

        private void Start()
        {
            _dialogController = FindObjectOfType<DialogsController>(true);

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
                List<string> events = new List<string>();

                if (_step > 0)
                {
                    _currentBranch.Phrases[_step - 1].TriggeringAfterActions();
                }

                if (_step < _currentBranch.Phrases.Count)
                {
                    _dialogController.SetPhrase(_currentBranch.Phrases[_step].Speaker, _currentBranch.Phrases[_step].PhraseText, _currentBranch.Phrases[_step].VoiceActing, _currentBranch.Phrases[_step]); ;
                    _step++;
                    return;
                }
                
                else if (_step >= _currentBranch.Phrases.Count)
                {
                    if (_currentBranch.Phrases[_step - 1].ActionsAfterPhrase != null)
                    {
                        for (int i = 0; i < _currentBranch.Phrases[_step - 1].ActionsAfterPhrase.GetPersistentEventCount(); i++)
                        {
                            events.Add(_currentBranch.Phrases[_step - 1].ActionsAfterPhrase.GetPersistentMethodName(i));
                        }
                    }

                    if (!events.Contains(nameof(SetStep)) && !events.Contains(nameof(OnChoice)) && !events.Contains(nameof(SetCurrentBranch)) && !events.Contains(nameof(EndDialog)))
                    {
                        EndDialog();
                    }
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

            for (int i = 0; i < _allChoicesList[choiceNumber].ChoicesList.Count; i++)
            {
                _dialogController.AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = AllChoicesList[choiceNumber].ChoicesList[i].AnswerText;
                _dialogController.AnswerButtons[i].onClick = AllChoicesList[choiceNumber].ChoicesList[i].AnswerEvent;
            }

            for (int i = 0; i < _allChoicesList[choiceNumber].ChoicesList.Count; i++)
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

            public UnityEvent ActionsAfterPhrase { get => _actionsAfterPhrase; }
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

            public void SetActions(UnityEvent actions)
            {
                _actionsAfterPhrase = actions;
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
            [SerializeField] private List<ChoiceElement> _choicesList;

            public List<ChoiceElement> ChoicesList { get => _choicesList; }
        }

        [System.Serializable]
        public struct ChoiceElement
        {
            [SerializeField] private string _answerText;
            
            [Space(25f)]

            [SerializeField] private Button.ButtonClickedEvent _answerEvent;

            public string AnswerText { get => _answerText; }
            public Button.ButtonClickedEvent AnswerEvent { get => _answerEvent; }
        }
        #endregion

        
    }
}