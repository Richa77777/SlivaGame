using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _nameColor;

    public string Name { get { return _name; } }
    public string NameColor { get { return _nameColor;} }
}
