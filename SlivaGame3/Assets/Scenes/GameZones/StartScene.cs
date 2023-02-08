using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    private SaveLoadScript _saveLoadScript;

    private void Start()
    {
        _saveLoadScript = FindObjectOfType<SaveLoadScript>(true);

        _saveLoadScript.Load();
        _saveLoadScript.Save();
    }
}
