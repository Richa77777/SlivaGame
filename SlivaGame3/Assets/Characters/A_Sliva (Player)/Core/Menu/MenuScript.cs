using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MenuScript : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryTab;
        [SerializeField] private GameObject _tasksTab;
        
        public void OpenInventory()
        {
            gameObject.SetActive(false);
            _inventoryTab.SetActive(true);
        }

        public void OpenTasks()
        {
            gameObject.SetActive(false);
            _tasksTab.SetActive(true);
        }
    }
}
