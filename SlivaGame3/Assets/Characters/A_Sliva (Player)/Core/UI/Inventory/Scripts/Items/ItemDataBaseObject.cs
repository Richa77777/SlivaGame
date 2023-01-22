using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Item Database", menuName = "InventorySystem/Items/ItemDataBase", order = 0)]
    public class ItemDataBaseObject : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private ItemObject[] _items;

        private Dictionary<int, ItemObject> _getItem = new Dictionary<int, ItemObject>();

        public Dictionary<int, ItemObject> GetItem { get { return _getItem; } }

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i].ID = i;
                _getItem.Add(i, _items[i]);
            }
        }

        public void OnBeforeSerialize()
        {
            _getItem = new Dictionary<int, ItemObject>();
        }
    }
}
