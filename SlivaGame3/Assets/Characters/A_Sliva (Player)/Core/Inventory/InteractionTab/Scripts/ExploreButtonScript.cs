using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogSystem;

namespace InteractionTab
{
    public class ExploreButtonScript : MonoBehaviour
    {
        private DialogsController _dialogsController;
        private Dialog _dialog;
        private Character _sliva;

        [SerializeField] private string _text;
        [SerializeField] private AudioClip _voiceActing;

        private void Start()
        {
            _dialogsController = FindObjectOfType<DialogsController>();
            _dialog = GetComponent<Dialog>();
            _sliva = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        }

        public void Explore()
        {
            _dialog.BranchesList[0].Phrases[0].SetSpeaker(_sliva);
            _dialog.BranchesList[0].Phrases[0].SetPhraseText(_text);
            _dialog.BranchesList[0].Phrases[0].SetVoiceActing(_voiceActing);

            _dialog.StartDialog();
        }
    }
}
