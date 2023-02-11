using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.Events;

namespace InteractionTab
{
    public class InteractionButtonScript : MonoBehaviour
    {
        private PlayerTalk _playerTalk;

        [SerializeField] private string _text;
        [SerializeField] private AudioClip _voiceAction;
        [SerializeField] private UnityEvent _actions; 

        private void Start()
        {
            _playerTalk = FindObjectOfType<PlayerTalk>();
        }

        public void StartInteract()
        {
            _playerTalk.ClearAll();
            _playerTalk.SetText(_text);
            _playerTalk.SetVoiceAction(_voiceAction);
            _playerTalk.SetActions(_actions);
            _playerTalk.PlayDialog();
        }
    }
}
