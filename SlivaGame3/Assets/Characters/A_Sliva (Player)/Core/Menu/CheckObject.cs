using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> _whatOff = new List<GameObject>();
    [SerializeField] private List<GameObject> _object = new List<GameObject>();

    private int n = 0;

    private void Update()
    {
        Check();
    }

    private void Check()
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
