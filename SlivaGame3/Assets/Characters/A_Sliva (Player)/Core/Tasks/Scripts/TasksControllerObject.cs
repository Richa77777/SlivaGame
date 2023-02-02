using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksSpace
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
            if (_container.GetTasksInProgress.Count < 5)
            {
                for (int i = 0; i < _container.GetTasks.Count; i++)
                {
                    if (_container.GetTasks[i].Task == task)
                    {
                        return false;
                    }
                }

                _container.GetTasks.Add(new TaskSlot(task, task.Subtasks));
                return true;
            }

            return false;
        }

        public void ClearContainer()
        {
            _container.GetTasks.Clear();
        }
    }

    [System.Serializable]
    public class Tasks
    {
        [SerializeField] private List<TaskSlot> _tasks = new List<TaskSlot>();

        private List<TaskSlot> _tasksInProgress = new List<TaskSlot>();
        private List<TaskSlot> _tasksCompleted = new List<TaskSlot>();
        private List<TaskSlot> _tasksFailed = new List<TaskSlot>();

        public List<TaskSlot> GetTasks { get => _tasks; }
        public List<TaskSlot> GetTasksInProgress
        {
            get
            {
                _tasksInProgress = new List<TaskSlot>();

                for (int i = 0; i < _tasks.Count; i++)
                {
                    if (_tasks[i].TaskState == TaskStates.inProgress)
                    {
                        _tasksInProgress.Add(_tasks[i]);
                    }
                }

                return _tasksInProgress;
            }
        }
        public List<TaskSlot> GetTasksCompleted
        {
            get
            {
                _tasksCompleted = new List<TaskSlot>();

                for (int i = 0; i < _tasks.Count; i++)
                {
                    if (_tasks[i].TaskState == TaskStates.Completed)
                    {
                        _tasksCompleted.Add(_tasks[i]);
                    }
                }

                return _tasksCompleted;
            }
        }
        public List<TaskSlot> GetTasksFailed
        {
            get
            {
                _tasksFailed = new List<TaskSlot>();

                for (int i = 0; i < _tasks.Count; i++)
                {
                    if (_tasks[i].TaskState == TaskStates.Failed)
                    {
                        _tasksFailed.Add(_tasks[i]);
                    }
                }

                return _tasksFailed;
            }
        }

        public void SetTasksList(List<TaskSlot> list)
        {
            _tasks = list;
        }

    }

    [System.Serializable]
    public class TaskSlot
    {
        [SerializeField] private TaskObject _task;

        [Space(5f)]
        [SerializeField] private List<Subtask> _subtasks;
        [SerializeField] private int _subtaskStep;
        [Space(5f)]

        //[SerializeField] private bool _taskIsHidden;
        [SerializeField] private TaskStates _taskState = TaskStates.inProgress;

        public TaskObject Task { get => _task; }
        public List<Subtask> Subtasks { get => _subtasks; }
        //public bool TaskIsHidden { get => _taskIsHidden; set => _taskIsHidden = value; }
        public int SubtaskStep { get => Mathf.Clamp(_subtaskStep, 0, _subtasks.Count); }
        public TaskStates TaskState { get => _taskState; }

        public TaskSlot(TaskObject task, List<Subtask> subtasks)
        {
            _task = task;
            _subtasks = subtasks;
        }

        public void NextSubtaskStep(int value)
        {
            _subtaskStep += value;
        }

        public void SetTaskState(TaskStates state)
        {
            _taskState = state;
        }
    }

    public enum TaskStates
    {
        inProgress,
        Failed,
        Completed
    }
}