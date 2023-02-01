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
        [SerializeField] private GameObject[] _subtaskObjects = new GameObject[25];
        [SerializeField] private TextMeshProUGUI[] _subtaskTexts = new TextMeshProUGUI[25];
        [SerializeField] private Image[] _subtaskImages = new Image[25];
        [SerializeField] private Sprite[] _subtaskCells = new Sprite[3];

        private List<TaskObject> _taskObjectsInButtons = new List<TaskObject>();


        private void Awake()
        {
            _playerTask = FindObjectOfType<PlayerTasksScript>().PlayerTasks;
        }

        private void Enable()
        {
            UpdateTaskButtonsTab();

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
            //int buttonNumber = 0;

            //for (int i = 0; i < _playerTask.Container.TasksGet.Count; i++)
            //{
            //    if (_playerTask.Container.TasksGet[i].TaskIsHidden == true)
            //    {
            //        if (_taskObjectsInButtons.Contains(_playerTask.Container.TasksGet[i].Task))
            //        {
            //            _taskButtons[_taskObjectsInButtons.IndexOf(_playerTask.Container.TasksGet[i].Task)].gameObject.SetActive(false);
            //            _taskObjectsInButtons.RemoveAt(_taskObjectsInButtons.IndexOf(_playerTask.Container.TasksGet[i].Task));

            //            Enable();
            //        }
            //    }
            //}

            //for (int i = 0; i < _playerTask.Container.TasksGet.Count; i++)
            //{
            //    if (_playerTask.Container.TasksGet[i].TaskIsHidden == false)
            //    {
            //        _taskButtons[buttonNumber].SetActive(true);
            //        _taskNameButtonText[buttonNumber].text = _playerTask.Container.TasksGet[i].Task.TaskName;

            //        if (_taskObjectsInButtons.Contains(_playerTask.Container.TasksGet[i].Task) == false)
            //        {
            //            _taskObjectsInButtons.Insert(buttonNumber, _playerTask.Container.TasksGet[i].Task);
            //        }

            //        buttonNumber++;
            //    }
            //}
        }

        public void UpdateTaskInfoTab(int taskIndex)
        {
            _taskInfoNameText.gameObject.SetActive(true);
            _taskInfoDescriptionText.gameObject.SetActive(true);

            _taskInfoNameText.text = _playerTask.Container.TasksGet[taskIndex].Task.TaskName;
            _taskInfoDescriptionText.text = _playerTask.Container.TasksGet[taskIndex].Task.TaskDescription;

            for (int i = 0; i < _playerTask.Container.TasksGet[taskIndex].Subtasks.Count; i++)
            {
                if (_playerTask.Container.TasksGet[taskIndex].Subtasks[i].isHidden == false)
                {
                    _subtaskObjects[i].SetActive(true);
                    _subtaskTexts[i].text = _playerTask.Container.TasksGet[taskIndex].Subtasks[i].SubtaskText;
                    //_subtaskImages[i].sprite = _playerTask.Container.TasksGet[taskIndex].Subtasks[i].SubtaskState == TaskStates.inProgress ? _subtaskCells[0] : _subtaskCells[1];
                }

                else if (_playerTask.Container.TasksGet[taskIndex].Subtasks[i].isHidden == true)
                {
                    _subtaskObjects[i].SetActive(false);
                }
            }
        }
    }
}