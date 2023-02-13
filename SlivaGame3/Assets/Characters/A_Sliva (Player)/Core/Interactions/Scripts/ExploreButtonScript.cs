using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DialogSystem;

namespace InteractionTab
{
    public class ExploreButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        private Dialog _dialog;
        private SetSoundAllButtons _soundAllButtons;

        [SerializeField] private string _text;
        [SerializeField] private AudioClip _voiceActing;
        [SerializeField] private UnityEvent _actions;

        [Space(10f)]

        [SerializeField] private UnityEvent _extraActions;

        private void Start()
        {
            _soundAllButtons = FindObjectOfType<SetSoundAllButtons>(true);
            _dialog = GameObject.FindGameObjectWithTag("Player").GetComponent<Dialog>();
        }

        public void Explore()
        {
            Debug.Log(_dialog);
            Debug.Log(_soundAllButtons);
            Debug.Log(_text);
            Debug.Log(_voiceActing);
            Debug.Log(_actions);
            Debug.Log(_extraActions);

            _extraActions?.Invoke();

            _dialog.BranchesList[0].Phrases[0].SetPhraseText(_text);
            _dialog.BranchesList[0].Phrases[0].SetVoiceActing(_voiceActing);
            _dialog.BranchesList[0].Phrases[0].SetActions(_actions);

            _dialog.StartDialog();
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            _soundAllButtons.PlaySoundButton();
            Explore();
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }
    }
}
