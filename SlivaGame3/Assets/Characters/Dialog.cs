using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DialogSystem
{
    public class Dialog : MonoBehaviour
    {
        private DialogController _dialogController;
        
        [SerializeField] private AllBranches _allBranches = new AllBranches();

        private List<Phrase> _currentBranch;
        private int _step = 0;

        private void Start()
        {
            _dialogController = FindObjectOfType<DialogController>();
            _currentBranch = _allBranches.AllBranchesList[0].Branch;
        }


        private void Update()
        {
            CheckTouch();
        }


        [System.Serializable]
        public struct Phrase
        {
            [SerializeField] private UnityEvent _actionsBeforePhrase;
            [SerializeField] private UnityEvent _actionsAfterPhrase;

            [SerializeField] private Character _speaker;

            [TextArea(6, 6)]
            [SerializeField] private string _phraseText;
            [SerializeField] private AudioClip _voiceActing;

            public Character Speaker { get { return _speaker; } }
            public string PhraseText { get { return _phraseText; } }
            public AudioClip VoiceActing { get { return _voiceActing; } }

            public void TriggeringBeforeActions()
            {
                _actionsBeforePhrase?.Invoke();
            }

            public void TriggeringAfterActions()
            {
                _actionsAfterPhrase?.Invoke();
            }
        }

        [System.Serializable]
        public struct BranchList
        {
            [SerializeField] private List<Phrase> _branch;

            public List<Phrase> Branch { get { return _branch; } }

        }

        [System.Serializable]
        public struct AllBranches
        {
            [SerializeField] private List<BranchList> _allBranchesList;

            public List<BranchList> AllBranchesList { get { return _allBranchesList; } }
        }

        private void CheckTouch()
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.touchCount > 0)
            {
                if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (_step < _currentBranch.Count && _dialogController.MightSetDialog == true)
                    {
                        _currentBranch[_step].TriggeringBeforeActions();

                        _dialogController.SetDialog(_currentBranch[_step].Speaker, _currentBranch[_step].PhraseText, _currentBranch[_step].VoiceActing, _currentBranch[_step]);

                        _step++;
                    }
                }
            }
        }

        public void SetCurrentBranch(int branchNumber)
        {
            _currentBranch = _allBranches.AllBranchesList[branchNumber].Branch;
            _step = 0;
        }
    }
}