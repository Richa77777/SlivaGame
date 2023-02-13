using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogSystem;
using UnityEngine.Events;

namespace Player
{
    public class PlayerTalk : MonoBehaviour
    {
        private Dialog _playerDialog;

        private void Awake()
        {
            _playerDialog = GetComponent<Dialog>();
        }

        public void SetText(string text)
        {
            _playerDialog.BranchesList[0].Phrases[0].SetPhraseText(text);
        }
        public void SetVoiceAction(AudioClip voiceAction)
        {
            _playerDialog.BranchesList[0].Phrases[0].SetVoiceActing(voiceAction);
        }

        public void SetActions(UnityEvent actions)
        {
            _playerDialog.BranchesList[0].Phrases[0].SetActions(actions);
        }

        public void ClearAll()
        {
            _playerDialog.BranchesList[0].Phrases[0].SetPhraseText(null);
            _playerDialog.BranchesList[0].Phrases[0].SetVoiceActing(null);
            _playerDialog.BranchesList[0].Phrases[0].SetActions(null);
        }

        public void PlayDialog()
        {
            _playerDialog.StartDialog();
        }
    }
}
