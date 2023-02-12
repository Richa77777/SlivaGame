using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace TasksSpace
{
    public class TakeTask : MonoBehaviour
    {
        private TasksControllerObject _playerTasks;

        [SerializeField] private TaskObject _task;
        [SerializeField] private int _step;

        private void Start()
        {
            _playerTasks = FindObjectOfType<PlayerTasksScript>().PlayerTasks;
        }

        public void AddTask()
        {
            _playerTasks.AddTask(_task, _step);
        }
    }
}
