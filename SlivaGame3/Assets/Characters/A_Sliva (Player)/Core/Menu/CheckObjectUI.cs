using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _whatOff = new List<GameObject>();
    [SerializeField] private List<GameObject> _object = new List<GameObject>();

    private int n = 0;

    public static Action _checkObjects;

    private void OnEnable()
    {
        _checkObjects += Check;
    }

    private void OnDisable()
    {
        _checkObjects -= Check;
    }

    public void Check()
    {
        n = 0;

        for (int i = 0; i < _object.Count; i++)
        {
            if (_object[i].activeInHierarchy == false)
            {
                n++;
            }
        }

        for (int i = 0; i < _whatOff.Count; i++)
        {
            _whatOff[i].SetActive(n == _object.Count ? true : false);
        }
    }
}
