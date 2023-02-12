using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScene : MonoBehaviour
{
    private SaveLoadScript _saveLoadScript;

    [SerializeField] private UnityEvent _actionsOnStart = new UnityEvent();

    private void Start()
    {
        _saveLoadScript = FindObjectOfType<SaveLoadScript>(true);

        _saveLoadScript.Load();
        _saveLoadScript.Save();

        _actionsOnStart?.Invoke();
    }

    
}
