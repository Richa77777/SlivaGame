using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory
{
    [CreateAssetMenu(fileName = "New Inventory System", menuName = "InventorySystem/Inventory", order = 0)]
    public class InventoryObject : ScriptableObject
    {
        [SerializeField] private List<InventorySlot> _container = new List<InventorySlot>();

        public List<InventorySlot> Container { get { return _container; } } 

        public void AddItem(ItemObject item, int count)
        {
            for (int i = 0; i < _container.Count - 1; i++)
            {
                if (_container[i].Item == item)
                {
                    _container[i].AddAmount(count);
                    return;
                }
            }

            if (_container.Count < 9)
            {
                _container.Add(new InventorySlot(item, count));
            }
        }

        public void ClearContainer()
        {
            _container.Clear();
        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] private ItemObject _item;
        [SerializeField] private int _count;

        [SerializeField] private Sprite _itemSprite;

        public ItemObject Item { get { return _item; } }
        public int Count { get { return _count; } }
        public Sprite ItemSprite { get { return _itemSprite; } }

        public InventorySlot(ItemObject item, int count)
        {
            _item = item;
            _count = Mathf.Clamp(count, 0, 99);
        }

        public void AddAmount(int count)
        {
            _count += Mathf.Clamp(count, 0, 99);
        }
    }
}
