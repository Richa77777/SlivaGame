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

                            for (int j = 0; j < _container.Items.Count; j++)
                            {
                                DisplayInventory._cellOnOff(_container.Items[j].ItemsCount > 0 ? true : false, j);
                                DisplayInventory._cellSetCount(_container.Items[j].ItemsCount, j);
                                DisplayInventory._cellSetImage(_container.Items[j].Item.ItemSprite, j);
                                DisplayInventory._cellCountOnOff(_container.Items[j].ItemsCount > 1 ? true : false, j);
                                DisplayInventory._cellImageOnOff(_container.Items[j].Item.ItemSprite != null ? true : false, j, _container.Items[j].Item.ItemSprite);
                            }

                            for (int j = _container.Items.Count; j < _inventoryLimit - _container.Items.Count; j++)
                            {
                                DisplayInventory._cellOnOff(false, j);
                            }

                            return;
                        }

                        _container.Items[i].AddAmount(count);

                        DisplayInventory._cellOnOff(_container.Items[i].ItemsCount > 0 ? true : false, i);
                        DisplayInventory._cellSetCount(_container.Items[i].ItemsCount, i);
                        DisplayInventory._cellSetImage(_container.Items[i].Item.ItemSprite, i);
                        DisplayInventory._cellCountOnOff(_container.Items[i].ItemsCount > 1 ? true : false, i);
                        return;
                    }
                }

                if (count > 0)
                {
                    _container.Items.Add(new InventorySlot(item, count));

                    DisplayInventory._cellOnOff(_container.Items[_container.Items.Count - 1].ItemsCount > 0 ? true : false, _container.Items.Count - 1);
                    DisplayInventory._cellSetCount(_container.Items[_container.Items.Count - 1].ItemsCount, _container.Items.Count - 1);
                    DisplayInventory._cellSetImage(_container.Items[_container.Items.Count - 1].Item.ItemSprite, _container.Items.Count - 1);
                    DisplayInventory._cellCountOnOff(_container.Items[_container.Items.Count - 1].ItemsCount > 1 ? true : false, _container.Items.Count - 1);
                    DisplayInventory._cellImageOnOff(_container.Items[_container.Items.Count - 1].Item.ItemSprite != null ? true : false, _container.Items.Count - 1, _container.Items[_container.Items.Count - 1].Item.ItemSprite);
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

            for (int i = _container.Items.Count; i < _inventoryLimit; i++)
            {
                DisplayInventory._cellOnOff(false, i);
            }
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
