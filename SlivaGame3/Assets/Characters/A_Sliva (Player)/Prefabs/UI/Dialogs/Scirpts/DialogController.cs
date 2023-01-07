using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class DialogController : MonoBehaviour
{
    [SerializeField] private AudioClip _dialogSound;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private float _timeBtwnChars = 0;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _dialogSound;
    }

    private void Start()
    {
        SetDialog("Слива", "#AA4BC0", "Здравствуйте ещё раз, Светлана Великая!");
    }

    public void SetDialog(string Name, string Color, string Text)
    {
        StartCoroutine(DialogPlayback(Name, Color, Text));
    }

    private IEnumerator DialogPlayback(string Name, string Color, string Text)
    {
        string nameText = Name;
        string nameColor = Color;
        string name = $"<size={_dialogText.fontSize + 5}><b><color={nameColor}>{nameText}:</color></b></size>";

        string fullText = $"{name} {Text}";


        for (int i = name.Length; i <= fullText.Length; i++)
        {
            if (fullText.ToCharArray()[i - 1].ToString() == "<")
            {
                while (fullText?.ToCharArray()?[i - 1].ToString() != ">")
                {
                    i++;
                }
            }

            if (fullText.ToCharArray()[i - 1].ToString() != "<" && fullText.ToCharArray()[i - 1].ToString() != ">")
            {
                _dialogText.text = fullText.Substring(0, i);

                if (string.IsNullOrWhiteSpace(fullText.ToCharArray()[i - 1].ToString()) == false)
                {
                    _audioSource.Play();
                }

                yield return new WaitForSeconds(_timeBtwnChars);
            }
        }
    }
}