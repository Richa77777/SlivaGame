using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksSpace
{
    public class SubtaskStateSet : MonoBehaviour
    {
        private TasksControllerObject _playerTasks;

        [SerializeField] private TaskObject _task;
        [SerializeField] private int _subtaskId;
        [SerializeField] private TaskStates _state;

        private void Start()
        {
            _playerTasks = FindObjectOfType<Player.PlayerTasksScript>().PlayerTasks;
        }

        public void SetState()
        {
            TaskSlot currentSlot = null;
            int subtaskIndex = 0;

            for (int i = 0; i < _playerTasks.Container.GetTasks.Count; i++)
            {
                if (_playerTasks.Container.GetTasks[i].Task == _task)
                {
                    currentSlot = _playerTasks.Container.GetTasks[i];
                    break;
                }
            }

            for (int i = 0; i < currentSlot.Subtasks.Count; i++)
            {
                if (currentSlot.Subtasks[i].SubtaskId == _subtaskId)
                {
                    subtaskIndex = currentSlot.Subtasks.IndexOf(currentSlot.Subtasks[i]);
                    break;
                }
            }

            if (currentSlot != null)
            {
                currentSlot.SetSubtaskState(subtaskIndex, _state);

            }
        }
    }
}
