using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tasks
{
    [CreateAssetMenu(fileName = "New Tasks Controller", menuName = "Tasks/Tasks Controller", order = -99)]
    public class TasksControllerObject : ScriptableObject
    {
        [SerializeField] private Tasks _container;

        public Tasks Container { get => _container; }

        public bool AddTask(TaskObject task)
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

        public void ClearContainer()
        {
            _container.TasksGet.Clear();
        }
    }

    [System.Serializable]
    public class Tasks
    {
        [SerializeField] private List<TaskSlot> _tasks = new List<TaskSlot>();

        public List<TaskSlot> TasksGet { get => _tasks; }
    }

    [System.Serializable]
    public class TaskSlot
    {
        [SerializeField] private TaskObject _task;
        [SerializeField] private List<Subtask> _subtasks;
        [SerializeField] private bool _taskIsCompleted;

        public TaskObject Task { get => _task; }
        public List<Subtask> Subtasks { get => _subtasks; }
        public bool TaskIsCompleted { get => _taskIsCompleted; set => _taskIsCompleted = value; }


        public TaskSlot(TaskObject task, List<Subtask> subtasks)
        {
            _task = task;
            _subtasks = subtasks;
        }
    }
}