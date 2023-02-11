using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InventorySpace;
using Player;
using Items;

namespace InteractionTab
{
    public class UseItemButton : MonoBehaviour
    {
        [SerializeField] ItemObject _needObject;

        [Space(10f)]

        [Header("If True")]
        [SerializeField] string _text; // If True
        [SerializeField] AudioClip _voiceAction; // If True

        [Space(25f)]

        [Header("Actions")]
        [SerializeField] UnityEvent _actionsTrue;
        [SerializeField] UnityEvent _actionsFalse;

        [Space(25f)]

        [SerializeField] private List<ItemTalk> _itemsTalk = new List<ItemTalk>();

        private GameObject _inventoryTab;
        private ChooseItem _chooseItem;

        public ItemObject NeedObject { get => _needObject; }
        public string TextGet { get => _text; }
        public AudioClip VoiceAction { get => _voiceAction; }
        public UnityEvent ActionsTrue { get => _actionsTrue; }
        public UnityEvent ActionsFalse { get => _actionsFalse; }
        public List<ItemTalk> ItemsTalk { get => _itemsTalk; }

        private void Start()
        {
            _chooseItem = FindObjectOfType<ChooseItem>(true);
            _inventoryTab = _chooseItem.gameObject;
        }

        public void OpenChooseTab()
        {
            _inventoryTab.SetActive(true);

            _chooseItem.SetLastButton(this);
            _chooseItem.StartChoose();
        }

        [System.Serializable]
        public struct ItemTalk
        {
            [SerializeField] private ItemObject _item;
            [SerializeField] private string _text;
            [SerializeField] private AudioClip _voiceAction;
            [SerializeField] private UnityEvent _actions;

            public ItemObject ItemGet { get => _item; }
            public string TextGet { get => _text; }
            public AudioClip VoiceActionGet { get => _voiceAction; }
            public UnityEvent ActionsGet { get => _actions; }
        }
    }
}
