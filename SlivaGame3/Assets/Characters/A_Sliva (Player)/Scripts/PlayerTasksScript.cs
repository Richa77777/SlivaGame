using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tasks;

namespace Player
{
    public class PlayerTasksScript : MonoBehaviour
    {
        [SerializeField] private TasksControllerObject _playerTasks;

        public TasksControllerObject PlayerTasks { get { return _playerTasks; } }

        private void OnApplicationQuit()
        {
            _playerTasks.ClearContainer();
        }
    }
}
