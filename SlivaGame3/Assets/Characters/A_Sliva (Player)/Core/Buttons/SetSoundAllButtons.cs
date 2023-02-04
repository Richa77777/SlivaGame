using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SetSoundAllButtons : MonoBehaviour
{
    private List<Button> _buttons = new List<Button>();

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickSound;
 
    private void Awake()
    {
        _buttons = FindObjectsOfType<Button>(true).ToList();
        _audioSource.clip = _clickSound;
    }

    private void Start()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].onClick.AddListener(PlaySoundButton);
        }
    }

    public void PlaySoundButton()
    {
        _audioSource.Play();
    }
}

