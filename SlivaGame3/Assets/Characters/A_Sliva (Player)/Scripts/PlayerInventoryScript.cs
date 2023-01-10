using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class PlayerInventoryScript : MonoBehaviour
    {
        [SerializeField] private InventoryObject _playerInventory;

        public InventoryObject PlayerInventory { get { return _playerInventory; } }

        private void OnApplicationQuit()
        {
            _playerInventory.ClearContainer();
        }
    }
}