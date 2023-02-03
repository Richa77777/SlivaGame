using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _whatOff = new List<GameObject>();

    private void OnEnable()
    {
        for (int i = 0; i < _whatOff.Count; i++)
        {
            _whatOff[i].SetActive(false);
        }
    }
}
