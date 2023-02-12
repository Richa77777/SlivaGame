using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InteractionTab
{
    public class ObjectTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _object;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _object.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _object.gameObject.SetActive(false);
            }
        }

        public void Disable()
        {
            _object.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
