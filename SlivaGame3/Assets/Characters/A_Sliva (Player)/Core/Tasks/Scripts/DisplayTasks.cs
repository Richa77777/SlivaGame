using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;
using TMPro;

namespace Tasks
{
    public class DisplayTasks : MonoBehaviour
    {
        private TasksControllerObject _playerTask;

        [Header("Buttons")]
        [SerializeField] private GameObject[] _taskButtons = new GameObject[5];
        [SerializeField] private TextMeshProUGUI[] _taskNameButtonText = new TextMeshProUGUI[5];

        [Space(5f)]
        [Header("Info")]
        [SerializeField] private TextMeshProUGUI _taskInfoNameText;
        [SerializeField] private TextMeshProUGUI _taskInfoDescriptionText;
        [Space(25f)]
        [SerializeField] private TextMeshProUGUI[] _subtaskTexts = new TextMeshProUGUI[25];
        [SerializeField] private Image[] _subtaskImages = new Image[25];

        private void Awake()
        {
            _playerTask = FindObjectOfType<PlayerTasksScript>().PlayerTasks;
        }

        private void OnEnable()
        {
            if (_playerTask.Container.TasksGet.Count - _playerTask.Container.TasksHiddenGet.Count >= 1)
            {
                _taskInfoNameText.gameObject.SetActive(true);
                _taskInfoDescriptionText.gameObject.SetActive(true);
                UpdateTaskInfoTab(0);
            }

            else if (_playerTask.Container.TasksGet.Count - _playerTask.Container.TasksHiddenGet.Count < 1)
            {
                _taskInfoNameText.gameObject.SetActive(false);
                _taskInfoDescriptionText.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            UpdateTaskButtonsTab();
        }

        public void UpdateTaskButtonsTab()
        {
            for (int i = 0; i < _playerTask.Container.TasksGet.Count - _playerTask.Container.TasksHiddenGet.Count; i++)
            {
                _taskNameButtonText[i].text = _playerTask.Container.TasksGet[i].Task.TaskName;
            }

            for (int i = 0; i < _playerTask.Container.TasksGet.Count - _playerTask.Container.TasksHiddenGet.Count; i++)
            {
                _taskButtons[i].SetActive(true);
            }

            for (int i = _playerTask.Container.TasksGet.Count - _playerTask.Container.TasksHiddenGet.Count + 1; i < _playerTask.TasksLimit - (_playerTask.Container.TasksGet.Count - _playerTask.Container.TasksHiddenGet.Count); i++)
            {
                _taskButtons[i].SetActive(false);
            }
        }

        public void UpdateTaskInfoTab(int taskIndex)
        {
            _taskInfoNameText.gameObject.SetActive(true);
            _taskInfoDescriptionText.gameObject.SetActive(true);

            _taskInfoNameText.text = _playerTask.Container.TasksGet[taskIndex].Task.TaskName;
            _taskInfoDescriptionText.text = _playerTask.Container.TasksGet[taskIndex].Task.TaskDescription;
        }
    }
}