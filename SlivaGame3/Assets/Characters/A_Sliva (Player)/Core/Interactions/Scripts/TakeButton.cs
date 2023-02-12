using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Items;
using DialogSystem;
using InventorySpace;

namespace InteractionTab
{
    public class TakeButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        private InventoryObject _inventory;
        private Dialog _dialog;
        private SetSoundAllButtons _soundAllButtons;

        [SerializeField] private ItemObject _item;
        [Range(0, 99)] [SerializeField] private int _count;
        [SerializeField] private UnityEvent _extraActions;

        [Space(10f)]

        [SerializeField] private string _text;
        [SerializeField] private AudioClip _voiceActing;
        [SerializeField] private UnityEvent _actions;

        private void Start()
        {
            _dialog = GameObject.FindGameObjectWithTag("Player").GetComponent<Dialog>();
            _soundAllButtons = FindObjectOfType<SetSoundAllButtons>();
            _inventory = FindObjectOfType<Player.PlayerInventoryScript>().PlayerInventory;
        }

        public void AddItem()
        {
            _inventory.AddItem(_item, _count);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _soundAllButtons.PlaySoundButton();

            if (_text != null)
            {
                _dialog.BranchesList[0].Phrases[0].SetPhraseText(_text);
                _dialog.BranchesList[0].Phrases[0].SetVoiceActing(_voiceActing);
                _dialog.BranchesList[0].Phrases[0].SetActions(_actions);
                _dialog.StartDialog();
            }

            AddItem();

            _extraActions?.Invoke();
            gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
    }
}
