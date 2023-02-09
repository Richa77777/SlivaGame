using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class RestartTabButton : MonoBehaviour
    {
        private Button _thisButton;

        private void Awake()
        {
            _thisButton = gameObject.GetComponent<Button>();
        }

        private void OnEnable()
        {
            _thisButton.interactable = true;
        }
    }
}
