using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class TakeItem : MonoBehaviour
    {
        [SerializeField] private ItemObject _item;

        [Range(0, 99)] [SerializeField] private int _count;

        private InventorySpace.InventoryObject _inventory;

        private void Start()
        {
            _inventory = FindObjectOfType<Player.PlayerInventoryScript>().PlayerInventory;
        }

        public void AddItem()
        {
            _inventory.AddItem(_item, _count);
        }
    }
}
