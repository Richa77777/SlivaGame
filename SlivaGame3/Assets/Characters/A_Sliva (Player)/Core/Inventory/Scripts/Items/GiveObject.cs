using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySpace;
using Items;

public class GiveObject : MonoBehaviour
{
    private InventoryObject _inventory;

    [SerializeField] private ItemObject _item;
    [Range(0, 99)] [SerializeField] private int _count;

    private void Start()
    {
        _inventory = FindObjectOfType<Player.PlayerInventoryScript>().PlayerInventory;
    }

    public void AddItem()
    {
        _inventory.AddItem(_item, _count);
    }
}
