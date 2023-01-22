using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace InventorySpace
{
    [CreateAssetMenu(fileName = "New Inventory System", menuName = "InventorySystem/Inventory", order = -100)]
    public class InventoryObject : ScriptableObject
    {
        [SerializeField] private string _savePath;

        [SerializeField] private Inventory _container;

        private const int _inventoryLimit = 9;

        public int InventoryLimit { get => _inventoryLimit; }

        public Inventory Container { get => _container; set => _container = value; }

        public void AddItem(Item item, int count)
        {
            if (_container.Items.Count < _inventoryLimit)
            {
                for (int i = 0; i < _container.Items.Count - 1; i++)
                {
                    if (_container.Items[i].Item.ID == item.ID)
                    {
                        _container.Items[i].AddAmount(count);
                        return;
                    }
                }

                _container.Items.Add(new InventorySlot(item.ID, item, count));
            }
        }

        public void ClearContainer()
        {
            _container.Items.Clear();
        }

        [ContextMenu("Save")]
        public void Save()
        {
            string saveData = JsonUtility.ToJson(this, true);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(string.Concat(Application.persistentDataPath, _savePath));
            bf.Serialize(file, saveData);
            file.Close();
        }

        [ContextMenu("Load")]
        public void Load()
        {
            if (File.Exists(string.Concat(Application.persistentDataPath, _savePath)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath, _savePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
                file.Close();
            }
        }

        [ContextMenu("Clear")]
        public void Clear()
        {
            Container = new Inventory();
        }
    }

    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private List<InventorySlot> _items = new List<InventorySlot>();
        public List<InventorySlot> Items { get { return _items; } }

    }

    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] private int _count;

        [SerializeField] private Item _item;
        public int Count { get { return _count; } }
        public Item Item { get { return _item; } set { _item = value; } }

        public InventorySlot(int id, Item item, int count)
        {
            item.ID = id;
            _item = item;
            _count = Mathf.Clamp(count, 0, 99);
        }

        public void AddAmount(int count)
        {
            _count += Mathf.Clamp(count, 0, 99);
        }
    }
}
