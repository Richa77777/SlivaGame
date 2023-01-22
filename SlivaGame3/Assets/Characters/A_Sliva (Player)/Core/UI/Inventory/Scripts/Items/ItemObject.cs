using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Items
{
    public abstract class ItemObject : ScriptableObject
    {
        [TextArea(15, 20)]
        [SerializeField] private int _id;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _sprite;

        public int ID { get => _id; set => _id = value; }
        public Sprite ItemSprite { get => _sprite; }
    }

    [System.Serializable]
    public class Item
    {
        [SerializeField] private string _name;
        [SerializeField] private int _id;
        [SerializeField] private Sprite _itemSprite;

        public string Name { get => _name; }
        public int ID { get => _id; set => _id = value; }
        public Sprite ItemSprite { get { return _itemSprite; } }

        public Item(ItemObject item)
        {
            _name = item.name;
            _id = item.ID;
            _itemSprite = item.ItemSprite;
        }
    }
}