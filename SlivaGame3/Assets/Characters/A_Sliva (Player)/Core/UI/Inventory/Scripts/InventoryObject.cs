using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Inventory
{
    [CreateAssetMenu(fileName = "New Inventory System", menuName = "InventorySystem/Inventory", order = 0)]
    public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private ItemDataBaseObject _database;

        [SerializeField] private List<InventorySlot> _container = new List<InventorySlot>();

        public List<InventorySlot> Container { get { return _container; } }

        public void AddItem(ItemObject item, int count)
        {
            if (_container.Count < 9)
            {
                for (int i = 0; i < _container.Count - 1; i++)
                {
                    if (_container[i].Item == item)
                    {
                        _container[i].AddAmount(count);
                        return;
                    }
                }

                _container.Add(new InventorySlot(_database.GetId[item], item, count));
            }
        }

        public void ClearContainer()
        {
            _container.Clear();
        }

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < _container.Count; i++)
            {
                _container[i].Item = _database.GetItem[_container[i].ID];
            }
        }

        public void OnBeforeSerialize()
        {

        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] private int _id;
        [SerializeField] private ItemObject _item;
        [SerializeField] private int _count;

        [SerializeField] private Sprite _itemSprite;

        public int ID { get { return _id; } }
        public ItemObject Item { get { return _item; } set { _item = value; } }
        public int Count { get { return _count; } }
        public Sprite ItemSprite { get { return _itemSprite; } }

        public InventorySlot(int id, ItemObject item, int count)
        {
            _id = id;
            _item = item;
            _count = Mathf.Clamp(count, 0, 99);
        }

        public void AddAmount(int count)
        {
            _count += Mathf.Clamp(count, 0, 99);
        }
    }
}
