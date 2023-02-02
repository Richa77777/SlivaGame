using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TasksSpace
{
    public class DropdownTasksScript : MonoBehaviour
    {
        [SerializeField] private GameObject _arrow;
        [SerializeField] private GameObject _buttons;
        [SerializeField] private RectTransform _dropdownsHolder;

        private DisplayTasks _displayTasks;

        private void Start()
        {
            _displayTasks = FindObjectOfType<DisplayTasks>();
        }

        private void Update()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_dropdownsHolder); // change.
            LayoutRebuilder.ForceRebuildLayoutImmediate(_buttons.GetComponent<RectTransform>());
        }

        public void OpenCloseList()
        {
            _displayTasks.UpdateTaskButtonsTab();

            if (_buttons.activeInHierarchy == false)
            {
                _buttons.SetActive(true);
                _arrow.transform.localRotation = Quaternion.Euler(0, 0, 180);
            }

            else if (_buttons.activeInHierarchy == true)
            {
                _buttons.SetActive(false);
                _arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
