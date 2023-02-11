using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private GameObject _playerControls;

        private void Start()
        {
            _playerControls = GameObject.FindGameObjectWithTag("Controls");
        }

        public void BlockPlayer()
        {
            _playerControls.SetActive(false);
        }

        public void UnblockPlayer()
        {
            _playerControls.SetActive(true);
        }
    }
}