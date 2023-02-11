using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace InventorySpace
{
    [CreateAssetMenu(fileName = "New Inventory System", menuName = "Inventory System/Inventory", order = -100)]
    public class InventoryObject : ScriptableObject
    {
        //[SerializeField] private string _savePath;
        [SerializeField] private Inventory _container;

        private bool _chooseOn = false;
        private const int _inventoryLimit = 9;

        public int InventoryLimit { get => _inventoryLimit; }
        public Inventory Container { get => _container; }
        public bool ChooseOn { get => _chooseOn; set => _chooseOn = value; }

        public void AddItem(ItemObject item, int count)
        {
            if (_container.Items.Count < _inventoryLimit)
            {
                for (int i = 0; i < _container.Items.Count; i++)
                {
                    if (_container.Items[i].Item == item)
                    {
                        if (_container.Items[i].ItemsCount + count <= 0)
                        {
                            _container.Items.RemoveAt(i);
                            return;
                        }

                        _container.Items[i].AddAmount(count);
                        return;
                    }
                }

                if (count > 0)
                {
                    _container.Items.Add(new InventorySlot(item, count));
                }
            }
        }

        public void ClearContainer()
        {
            _container.Items.Clear();
        }

        [ContextMenu("Clear")]
        public void Clear()
        {
            _container.SetItemList(new List<InventorySlot>());
        }
    }

    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private List<InventorySlot> _items = new List<InventorySlot>();
        public List<InventorySlot> Items { get { return _items; } }

        public void SetItemList(List<InventorySlot> list)
        {
            _items = list;
        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] private ItemObject _item;
        [SerializeField] private int _count;

        public ItemObject Item { get { return _item; } set { _item = value; } }
        public int ItemsCount { get { return _count; } }

        public InventorySlot(ItemObject item, int count)
        {
            _item = item;
            _count = Mathf.Clamp(count, 0, 99);
        }

        public void AddAmount(int count)
        {
            _count = Mathf.Clamp(_count + count, 0, 99);
        }
    }
}
