using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tasks
{
    [CreateAssetMenu(fileName = "New Tasks Controller", menuName = "Tasks/Tasks Controller", order = -99)]
    public class TasksControllerObject : ScriptableObject
    {
        [SerializeField] private Tasks _container;
        private const int _tasksLimit = 5;

        public Tasks Container { get => _container; }
        public int TasksLimit { get => _tasksLimit; }

        public bool AddTask(TaskObject task)
        {
            if (_container.TasksGet.Count - _container.TasksHiddenGet.Count < 5)
            {
                for (int i = 0; i < _container.TasksGet.Count; i++)
                {
                    if (_container.TasksGet[i].Task == task)
                    {
                        return false;
                    }
                }

                _container.TasksGet.Add(new TaskSlot(task, task.Subtasks));
                return true;
            }

            return false;
        }

        public void ClearContainer()
        {
            _container.TasksGet.Clear();
        }
    }

    [System.Serializable]
    public class Tasks
    {
        [SerializeField] private List<TaskSlot> _tasks = new List<TaskSlot>();
        private List<TaskSlot> _tasksHidden = new List<TaskSlot>();
        public List<TaskSlot> TasksGet { get => _tasks; }
        public List<TaskSlot> TasksHiddenGet
        { 
            get
            {
                _tasksHidden = new List<TaskSlot>();

                for (int i = 0; i < _tasks.Count; i++)
                {
                    if (_tasks[i].TaskIsHidden == true)
                    {
                        _tasksHidden.Add(_tasks[i]);
                    }
                }

                return _tasksHidden;
            }
        }

    }

    [System.Serializable]
    public class TaskSlot
    {
        [SerializeField] private TaskObject _task;
        [SerializeField] private List<Subtask> _subtasks;
        [SerializeField] private bool _taskIsCompleted;
        [SerializeField] private bool _taskIsHidden;

        public TaskObject Task { get => _task; }
        public List<Subtask> Subtasks { get => _subtasks; }
        public bool TaskIsCompleted { get => _taskIsCompleted; set => _taskIsCompleted = value; }
        public bool TaskIsHidden { get => _taskIsHidden; set => _taskIsHidden = value; }


        public TaskSlot(TaskObject task, List<Subtask> subtasks)
        {
            _task = task;
            _subtasks = subtasks;
        }
    }
}