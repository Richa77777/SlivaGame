using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    private SaveLoadScript _saveLoadScript;

    private void Awake()
    {
        _saveLoadScript = FindObjectOfType<SaveLoadScript>(true);
    }

    private void Start()
    {
        _saveLoadScript.Load();
        _saveLoadScript.Save();
    }
}
