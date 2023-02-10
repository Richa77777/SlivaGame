using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySpace;
using Player;
using Items;
using DialogSystem;

namespace InteractionTab
{
    public class ChooseItem : MonoBehaviour
    {
        private InventoryObject _playerInventory;
        private ItemObject _needItem;
        private UseItemButton _lastButton;

        private Dialog _dialog;
        [SerializeField] private GameObject _textChoose;
        [SerializeField] private GameObject[] _closeButtons = new GameObject[2];
        [SerializeField] private GameObject[] _chooseButtons = new GameObject[9];

        [SerializeField] private string[] _phrases = new string[5];
        [SerializeField] private AudioClip[] _voiceActions = new AudioClip[5];
        
        private void Awake()
        {
            _playerInventory = FindObjectOfType<PlayerInventoryScript>().PlayerInventory;
            _dialog = GameObject.FindGameObjectWithTag("Player").GetComponent<Dialog>();
        }

        public void StartChoose()
        {
            gameObject.SetActive(true);
            _textChoose.SetActive(true);
            _closeButtons[0].SetActive(false);
            _closeButtons[1].SetActive(true);

            for (int i = 0; i < _playerInventory.Container.Items.Count; i++)
            {
                _chooseButtons[i].SetActive(true);
            }
        }

        public void EndChoose()
        {
            for (int i = 0; i < _chooseButtons.Length; i++)
            {
                _chooseButtons[i].SetActive(false);
            }

            _textChoose.SetActive(false);
            _closeButtons[0].SetActive(true);
            _closeButtons[1].SetActive(false);
            gameObject.SetActive(false);
        }

        public void TryChooseItem(int slotIndex)
        {
            if (slotIndex <= _playerInventory.Container.Items.Count - 1)
            {
                if (_playerInventory.Container.Items[slotIndex].Item == _needItem)
                {
                    _lastButton.ItemIs();

                    EndChoose();
                }

                else if (_playerInventory.Container.Items[slotIndex].Item != _needItem)
                {
                    int randomPhraseIndex = Random.Range(0, _phrases.Length - 1);

                    _dialog.BranchesList[0].Phrases[0].SetPhraseText(_phrases[randomPhraseIndex]);
                    _dialog.BranchesList[0].Phrases[0].SetVoiceActing(_voiceActions[randomPhraseIndex]);
                    _dialog.StartDialog();

                    EndChoose();
                }
            }
        }

        public void SetNeedItem(ItemObject item)
        {
            _needItem = item;
        }

        public void SetLastButton(UseItemButton button)
        {
            _lastButton = button;
        }
    }
}
