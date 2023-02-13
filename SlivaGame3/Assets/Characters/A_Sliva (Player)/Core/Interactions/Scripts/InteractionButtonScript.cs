using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace InteractionTab
{
    public class InteractionButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        private PlayerTalk _playerTalk;

        [SerializeField] private string _text;
        [SerializeField] private AudioClip _voiceAction;
        [SerializeField] private UnityEvent _actions;

        [Space(10f)]

        [SerializeField] private UnityEvent _extraActions;

        private ObjectTrigger _objectTrigger;

        private void Start()
        {
            _playerTalk = FindObjectOfType<PlayerTalk>();
            _objectTrigger = transform.parent.GetComponentInChildren<ObjectTrigger>();
        }

        public void StartInteract()
        {
            _extraActions?.Invoke();

            if (_text != "")
            {
                _playerTalk.ClearAll();
                _playerTalk.SetText(_text);
                _playerTalk.SetVoiceAction(_voiceAction);
                _playerTalk.SetActions(_actions);
                _playerTalk.PlayDialog();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            StartInteract();
            _objectTrigger.Disable();
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }
    }
}
