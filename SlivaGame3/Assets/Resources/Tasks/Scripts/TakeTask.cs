using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Tasks
{
    public class TakeTask : MonoBehaviour
    {
        private TasksControllerObject _playerTasks;

        private void Start()
        {
            _playerTasks = FindObjectOfType<PlayerTasksScript>().PlayerTasks;
        }

        public void AddTask(TaskObject task)
        {
            _playerTasks.AddTask(task);
        }
    }
}
