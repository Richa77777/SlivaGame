using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _whatOff = new List<GameObject>();

    private void OnEnable()
    {
        CheckObjectUI._checkObjects?.Invoke();

        for (int i = 0; i < _whatOff.Count; i++)
        {
            _whatOff[i].SetActive(false);
        }
    }

    private void OnDisable()
    {
        CheckObjectUI._checkObjects?.Invoke();
    }
}
