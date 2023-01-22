using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private Items.ItemObject _item;

    private InventorySpace.InventoryObject _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Player.PlayerInventoryScript>().PlayerInventory;
    }

    public void AddItem(int count)
    {
        _inventory.AddItem(_item, count);
    }
}
