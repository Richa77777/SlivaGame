using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class DialogTrigger : MonoBehaviour
    {
        [SerializeField] private Dialog _dialog;
        private DialogButton _dialogButton;

        private bool _enabled;

        public bool Enabled { get => _enabled; set => _enabled = value; }

        private void Awake()
        {
            _dialogButton = FindObjectOfType<DialogButton>(true);
        }

        private void OnDisable()
        {
            _dialogButton.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && _enabled == true)
            {
                _dialogButton.gameObject.SetActive(true);
                _dialogButton.SetCurrentDialog(_dialog);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _dialogButton.SetCurrentDialog(null);
                _dialogButton.gameObject.SetActive(false);
            }
        }

    }
}
