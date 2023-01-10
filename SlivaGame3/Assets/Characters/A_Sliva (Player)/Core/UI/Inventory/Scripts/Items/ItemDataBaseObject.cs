using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Item Database", menuName = "InventorySystem/Items/ItemDataBase", order = 0)]
    public class ItemDataBaseObject : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField] private ItemObject[] _items;

        private Dictionary<ItemObject, int> _getId = new Dictionary<ItemObject, int>();
        private Dictionary<int, ItemObject> _getItem = new Dictionary<int, ItemObject>();

        public Dictionary<ItemObject, int> GetId { get { return _getId; } }
        public Dictionary<int, ItemObject> GetItem { get { return _getItem; } }

        public void OnAfterDeserialize()
        {
            _getId = new Dictionary<ItemObject, int>();
            _getItem = new Dictionary<int, ItemObject>();

            for (int i = 0; i < _items.Length; i++)
            {
                _getId.Add(_items[i], i);
                _getItem.Add(i, _items[i]);
            }
        }

        public void OnBeforeSerialize()
        {

        }
    }
}
