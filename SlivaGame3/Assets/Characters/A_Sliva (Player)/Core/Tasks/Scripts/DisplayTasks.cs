using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;
using TMPro;
using UnityEngine.Serialization;
using System;

namespace TasksSpace
{
    public class DisplayTasks : MonoBehaviour
    {
        private TasksControllerObject _playerTasks;

        [Header("Buttons")]

        [Header("inProgress")]
        [SerializeField] private GameObject[] _inProgressTaskButtons = new GameObject[5];
        [SerializeField] private TextMeshProUGUI[] _inProgressTaskNameButtonTexts = new TextMeshProUGUI[5];

        [Header("Completed")]
        [SerializeField] private GameObject[] _completedTaskButtons = new GameObject[30];
        [SerializeField] private TextMeshProUGUI[] _completedTaskNameButtonTexts = new TextMeshProUGUI[30];

        [Header("Failed")]
        [SerializeField] private GameObject[] _failedTaskButtons = new GameObject[30];
        [SerializeField] private TextMeshProUGUI[] _failedTaskNameButtonTexts = new TextMeshProUGUI[30];

        [Space(5f)]

        [Header("Info")]
        [SerializeField] private TextMeshProUGUI _taskInfoNameText;
        [SerializeField] private TextMeshProUGUI _taskInfoDescriptionText;

        [Space(25f)]

        [SerializeField] private GameObject[] _subtaskObjects = new GameObject[25];
        [SerializeField] private TextMeshProUGUI[] _subtaskTexts = new TextMeshProUGUI[25];
        [SerializeField] private Image[] _subtaskImages = new Image[25];

        [SerializeField] private Sprite[] _subtaskCellsSprites = new Sprite[3];

        private List<TaskObject> _taskObjectsInInProgressButtons = new List<TaskObject>();
        private List<TaskObject> _taskObjectsInCompletedButtons = new List<TaskObject>();
        private List<TaskObject> _taskObjectsInFailedButtons = new List<TaskObject>();

        [SerializeField] private RectTransform _dropdownsHolder;

        private void Awake()
        {
            _playerTasks = FindObjectOfType<PlayerTasksScript>().PlayerTasks;
        }

        public void Enable()
        {
            ClearInfo();
            ClearButtons();

            UpdateTaskButtonsTab();
        }

        public void UpdateTaskButtonsTab()
        {
            int index;

            for (int i = 0; i < _playerTasks.Container.GetTasksInProgress.Count; i++)
            {
                // In Progress
                if (!_taskObjectsInInProgressButtons.Contains(_playerTasks.Container.GetTasksInProgress[i].Task))
                {
                    if (_taskObjectsInCompletedButtons.Contains(_playerTasks.Container.GetTasksInProgress[i].Task))
                    {
                        _completedTaskButtons[_taskObjectsInCompletedButtons.IndexOf(_playerTasks.Container.GetTasksInProgress[i].Task)].gameObject.SetActive(false);
                        _taskObjectsInCompletedButtons.RemoveAt(_taskObjectsInCompletedButtons.IndexOf(_playerTasks.Container.GetTasksInProgress[i].Task));
                    }

                    if (_taskObjectsInFailedButtons.Contains(_playerTasks.Container.GetTasksInProgress[i].Task))
                    {
                        _failedTaskButtons[_taskObjectsInFailedButtons.IndexOf(_playerTasks.Container.GetTasksInProgress[i].Task)].gameObject.SetActive(false);
                        _taskObjectsInFailedButtons.RemoveAt(_taskObjectsInFailedButtons.IndexOf(_playerTasks.Container.GetTasksInProgress[i].Task));
                    }

                    _taskObjectsInInProgressButtons.Add(_playerTasks.Container.GetTasksInProgress[i].Task);

                    index = _taskObjectsInInProgressButtons.IndexOf(_playerTasks.Container.GetTasksInProgress[i].Task);

                    _inProgressTaskButtons[index].gameObject.SetActive(true);
                    _inProgressTaskNameButtonTexts[index].text = _playerTasks.Container.GetTasksInProgress[i].Task.TaskName;
                }
            }

            for (int i = 0; i < _playerTasks.Container.GetTasksCompleted.Count; i++)
            {
                // Completed
                if (!_taskObjectsInCompletedButtons.Contains(_playerTasks.Container.GetTasksCompleted[i].Task))
                {
                    if (_taskObjectsInInProgressButtons.Contains(_playerTasks.Container.GetTasksCompleted[i].Task))
                    {
                        _inProgressTaskButtons[_taskObjectsInInProgressButtons.IndexOf(_playerTasks.Container.GetTasksCompleted[i].Task)].gameObject.SetActive(false);
                        _taskObjectsInInProgressButtons.RemoveAt(_taskObjectsInInProgressButtons.IndexOf(_playerTasks.Container.GetTasksCompleted[i].Task));
                    }

                    if (_taskObjectsInFailedButtons.Contains(_playerTasks.Container.GetTasksCompleted[i].Task))
                    {
                        _failedTaskButtons[_taskObjectsInFailedButtons.IndexOf(_playerTasks.Container.GetTasksCompleted[i].Task)].gameObject.SetActive(false);
                        _taskObjectsInFailedButtons.RemoveAt(_taskObjectsInFailedButtons.IndexOf(_playerTasks.Container.GetTasksCompleted[i].Task));
                    }

                    _taskObjectsInCompletedButtons.Add(_playerTasks.Container.GetTasksCompleted[i].Task);

                    index = _taskObjectsInCompletedButtons.IndexOf(_playerTasks.Container.GetTasksCompleted[i].Task);

                    _completedTaskButtons[index].gameObject.SetActive(true);
                    _completedTaskNameButtonTexts[index].text = _playerTasks.Container.GetTasksCompleted[i].Task.TaskName;
                }
            }

            for (int i = 0; i < _playerTasks.Container.GetTasksFailed.Count; i++)
            {
                // Failed
                if (!_taskObjectsInFailedButtons.Contains(_playerTasks.Container.GetTasksFailed[i].Task))
                {
                    if (_taskObjectsInInProgressButtons.Contains(_playerTasks.Container.GetTasksFailed[i].Task))
                    {
                        _inProgressTaskButtons[_taskObjectsInInProgressButtons.IndexOf(_playerTasks.Container.GetTasksFailed[i].Task)].gameObject.SetActive(false);
                        _taskObjectsInInProgressButtons.RemoveAt(_taskObjectsInInProgressButtons.IndexOf(_playerTasks.Container.GetTasksFailed[i].Task));
                    }

                    if (_taskObjectsInCompletedButtons.Contains(_playerTasks.Container.GetTasksFailed[i].Task))
                    {
                        _completedTaskButtons[_taskObjectsInCompletedButtons.IndexOf(_playerTasks.Container.GetTasksFailed[i].Task)].gameObject.SetActive(false);
                        _taskObjectsInCompletedButtons.RemoveAt(_taskObjectsInCompletedButtons.IndexOf(_playerTasks.Container.GetTasksFailed[i].Task));
                    }

                    _taskObjectsInFailedButtons.Add(_playerTasks.Container.GetTasksFailed[i].Task);

                    index = _taskObjectsInFailedButtons.IndexOf(_playerTasks.Container.GetTasksFailed[i].Task);

                    _failedTaskButtons[index].gameObject.SetActive(true);
                    _failedTaskNameButtonTexts[index].text = _playerTasks.Container.GetTasksFailed[i].Task.TaskName;
                }
            }
        }

        public void UpdateTaskInfoInProgress(int taskIndex)
        {
            ClearInfo();

            _taskInfoNameText.gameObject.SetActive(true);
            _taskInfoDescriptionText.gameObject.SetActive(true);

            _taskInfoNameText.text = _playerTasks.Container.GetTasksInProgress[taskIndex].Task.TaskName;
            _taskInfoDescriptionText.text = _playerTasks.Container.GetTasksInProgress[taskIndex].Task.TaskDescription;

            for (int i = 0; i < _playerTasks.Container.GetTasksInProgress[taskIndex].SubtaskStep; i++)
            {
                if (_playerTasks.Container.GetTasksInProgress[taskIndex].Subtasks[i].isHidden == false)
                {
                    _subtaskObjects[i].SetActive(true);
                    _subtaskTexts[i].text = _playerTasks.Container.GetTasksInProgress[taskIndex].Subtasks[i].SubtaskText;

                    switch (_playerTasks.Container.GetTasksInProgress[taskIndex].Subtasks[i].SubtaskState)
                    {
                        case TaskStates.inProgress:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[0];
                            break;

                        case TaskStates.Completed:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[1];
                            break;

                        case TaskStates.Failed:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[2];
                            break;
                    }
                }

                else if (_playerTasks.Container.GetTasksInProgress[taskIndex].Subtasks[i].isHidden == true)
                {
                    _subtaskObjects[i].SetActive(false);
                }
            }
        }

        public void UpdateTaskInfoCompleted(int taskIndex)
        {
            ClearInfo();

            _taskInfoNameText.gameObject.SetActive(true);
            _taskInfoDescriptionText.gameObject.SetActive(true);

            _taskInfoNameText.text = _playerTasks.Container.GetTasksCompleted[taskIndex].Task.TaskName;
            _taskInfoDescriptionText.text = _playerTasks.Container.GetTasksCompleted[taskIndex].Task.TaskDescription;

            for (int i = 0; i < _playerTasks.Container.GetTasksCompleted[taskIndex].SubtaskStep; i++)
            {
                if (_playerTasks.Container.GetTasksCompleted[taskIndex].Subtasks[i].isHidden == false)
                {
                    _subtaskObjects[i].SetActive(true);
                    _subtaskTexts[i].text = _playerTasks.Container.GetTasksCompleted[taskIndex].Subtasks[i].SubtaskText;

                    switch (_playerTasks.Container.GetTasksCompleted[taskIndex].Subtasks[i].SubtaskState)
                    {
                        case TaskStates.inProgress:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[0];
                            break;

                        case TaskStates.Completed:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[1];
                            break;

                        case TaskStates.Failed:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[2];
                            break;
                    }
                }

                else if (_playerTasks.Container.GetTasksCompleted[taskIndex].Subtasks[i].isHidden == true)
                {
                    _subtaskObjects[i].SetActive(false);
                }
            }
        }

        public void UpdateTaskInfoFailed(int taskIndex)
        {
            ClearInfo();

            _taskInfoNameText.gameObject.SetActive(true);
            _taskInfoDescriptionText.gameObject.SetActive(true);

            _taskInfoNameText.text = _playerTasks.Container.GetTasksFailed[taskIndex].Task.TaskName;
            _taskInfoDescriptionText.text = _playerTasks.Container.GetTasksFailed[taskIndex].Task.TaskDescription;

            for (int i = 0; i < _playerTasks.Container.GetTasksFailed[taskIndex].SubtaskStep; i++)
            {
                if (_playerTasks.Container.GetTasksFailed[taskIndex].Subtasks[i].isHidden == false)
                {
                    _subtaskObjects[i].SetActive(true);
                    _subtaskTexts[i].text = _playerTasks.Container.GetTasksFailed[taskIndex].Subtasks[i].SubtaskText;

                    switch (_playerTasks.Container.GetTasksFailed[taskIndex].Subtasks[i].SubtaskState)
                    {
                        case TaskStates.inProgress:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[0];
                            break;

                        case TaskStates.Completed:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[1];
                            break;

                        case TaskStates.Failed:
                            _subtaskImages[i].sprite = _subtaskCellsSprites[2];
                            break;
                    }
                }

                else if (_playerTasks.Container.GetTasksFailed[taskIndex].Subtasks[i].isHidden == true)
                {
                    _subtaskObjects[i].SetActive(false);
                }
            }
        }

        private void ClearInfo()
        {
            _taskInfoNameText.gameObject.SetActive(false);
            _taskInfoDescriptionText.gameObject.SetActive(false);

            for (int i = 0; i < _subtaskObjects.Length; i++)
            {
                _subtaskObjects[i].SetActive(false);
            }
        }

        private void ClearButtons()
        {
            for (int i = 0; i < _inProgressTaskButtons.Length; i++)
            {
                _inProgressTaskButtons[i].SetActive(false);
            }

            for (int i = 0; i < _completedTaskButtons.Length; i++)
            {
                _completedTaskButtons[i].SetActive(false);
            }

            for (int i = 0; i < _failedTaskButtons.Length; i++)
            {
                _failedTaskButtons[i].SetActive(false);
            }
        }
    }
}