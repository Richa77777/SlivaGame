using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;
using InventorySpace;
using Player;

public class SaveLoadScript : PersistentMonoBehaviour
{
    public static SaveLoadScript PlayerSaveLoadScript;

    [NonZSerialized] private InventoryObject _inventory;
    [NonZSerialized] private Inventory _container;
    [SerializeField] private List<InventorySlot> _items;

    private void Start()
    {
        PlayerSaveLoadScript = this;

        _inventory = FindObjectOfType<PlayerInventoryScript>().PlayerInventory;
        _container = _inventory.Container;
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _items = _container.Items;

        ZSerialize.SaveScene();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        ZSerialize.LoadScene();
        
        _container.SetItemList(_items);
        _inventory.Load();
    }

    [ContextMenu("Delete All Saves")]
    public void DeleteAllSaves()
    {
        ZSerialize.DeleteAllSaveFiles();
    }
}
