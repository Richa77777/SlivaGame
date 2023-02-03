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
        [Space(10f)] [SerializeField] UnityEvent _actions; // if true

        private GameObject _inventoryTab;

        private ChooseItem _chooseItem;

        private void Start()
        {
            _inventoryTab = GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetChild(1).gameObject;
            _chooseItem = _inventoryTab.GetComponent<ChooseItem>();
        }

        public void OpenChooseTab()
        {
            _inventoryTab.SetActive(true);

            _chooseItem.SetLastButton(this);
            _chooseItem.SetNeedItem(_needObject);
            _chooseItem.StartChoose();
        }

        public void ItemIs()
        {
            _actions?.Invoke();
        }
    }
}
