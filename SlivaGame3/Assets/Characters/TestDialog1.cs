using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialog1 : Dialog
{
    [SerializeField] private List<Phrase> _branch1 = new List<Phrase>();

    private int _step = 0;

    private void Start()
    {
        DialogController._dialogController.SetDialog(_branch1[_step].Speaker.Name, _branch1[_step].Speaker.NameColor, _branch1[_step].PhraseText);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_step < _branch1.Count - 1 && DialogController._dialogController.MightSetDialog == true)
            {
                _step++;
                DialogController._dialogController.SetDialog(_branch1[_step].Speaker.Name, _branch1[_step].Speaker.NameColor, _branch1[_step].PhraseText);
            }
        }
    }
}
