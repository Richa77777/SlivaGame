using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksSpace
{
    public class SubtaskStepAddSet : MonoBehaviour
    {
        private TasksControllerObject _playerTasks;

        [SerializeField] private TaskObject _task;

        private void Start()
        {
            _playerTasks = FindObjectOfType<Player.PlayerTasksScript>().PlayerTasks;
        }

        public void AddStep(int value)
        {
            TaskSlot currentSlot = null;

            for (int i = 0; i < _playerTasks.Container.GetTasks.Count; i++)
            {
                if (_playerTasks.Container.GetTasks[i].Task == _task)
                {
                    currentSlot = _playerTasks.Container.GetTasks[i];
                    break;
                }
            }

            if (currentSlot != null)
            {
                currentSlot.AddSubtaskStep(value);
            }
        }

        public void SetStep(int value)
        {
            TaskSlot currentSlot = null;

            for (int i = 0; i < _playerTasks.Container.GetTasks.Count; i++)
            {
                if (_playerTasks.Container.GetTasks[i].Task == _task)
                {
                    currentSlot = _playerTasks.Container.GetTasks[i];
                    break;
                }
            }

            if (currentSlot != null)
            {
                currentSlot.SetSubtaskStep(value);
            }
        }
    }
}
