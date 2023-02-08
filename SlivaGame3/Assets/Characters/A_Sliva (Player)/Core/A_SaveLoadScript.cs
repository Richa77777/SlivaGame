using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;
using InventorySpace;
using TasksSpace;
using Player;

public class SaveLoadScript : PersistentMonoBehaviour
{
    public static SaveLoadScript PlayerSaveLoadScript;

    [NonZSerialized] private InventoryObject _inventory;
    [NonZSerialized] private Inventory _inventoryContainer;
    [SerializeField] private List<InventorySlot> _itemsList;

    [NonZSerialized] private TasksControllerObject _tasks;
    [NonZSerialized] private Tasks _tasksContainer;
    [SerializeField] private List<TaskSlot> _tasksList;


    private void Awake()
    {
        PlayerSaveLoadScript = this;

        _inventory = FindObjectOfType<PlayerInventoryScript>().PlayerInventory;
        _inventoryContainer = _inventory.Container;

        _tasks = FindObjectOfType<PlayerTasksScript>().PlayerTasks;
        _tasksContainer = _tasks.Container;
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _itemsList = _inventoryContainer.Items;
        _tasksList = _tasksContainer.GetTasks;

        ZSerialize.SaveScene();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        ZSerialize.LoadScene();
        
        _inventoryContainer.SetItemList(_itemsList);
        _tasksContainer.SetTasksList(_tasksList);
    }

    [ContextMenu("Delete All Saves")]
    public void DeleteAllSaves()
    {
        ZSerialize.DeleteAllSaveFiles();
    }
}
