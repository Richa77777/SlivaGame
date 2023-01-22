using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Items
{
    public abstract class ItemObject : ScriptableObject
    {
        [TextArea(15, 20)]
        [SerializeField] private string _description;
        [SerializeField] private Sprite _sprite;

        public Sprite ItemSprite { get => _sprite; }
    }
}