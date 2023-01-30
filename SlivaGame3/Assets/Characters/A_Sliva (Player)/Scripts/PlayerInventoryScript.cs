using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySpace;
using Items;

namespace Player
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