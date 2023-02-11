using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InteractionTab
{
    public class InteractionButtonTrigger : MonoBehaviour
    {
        [SerializeField] private Button _triggerButton;

        private void Start()
        {
            _triggerButton.onClick.AddListener(Disable);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _triggerButton.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _triggerButton.gameObject.SetActive(false);
            }
        }

        public void Disable()
        {
            _triggerButton.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
