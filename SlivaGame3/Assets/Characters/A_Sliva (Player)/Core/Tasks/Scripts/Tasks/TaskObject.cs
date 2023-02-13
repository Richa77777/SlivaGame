using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksSpace
{
    public abstract class TaskObject : ScriptableObject
    {
        [SerializeField] protected string _taskName;

        [Space(10f)]

        [TextArea(10, 15)] [SerializeField] protected string _taskDescription;

        [Space(25f)]

        [SerializeField] protected List<Subtask> _subtasks;

        public string TaskName { get => _taskName; }
        public string TaskDescription { get => _taskDescription; }
        public List<Subtask> Subtasks { get => _subtasks; }
    }

    [System.Serializable]
    public class Subtask
    {
        [SerializeField] private int _subtaskId;
        [SerializeField] private string _subtaskText;
        [SerializeField] private TaskStates _subtaskState;
        [SerializeField] private bool _isHidden;

        public int SubtaskId { get => _subtaskId; set => _subtaskId = value; }
        public string SubtaskText { get => _subtaskText; set => _subtaskText = value; }
        public TaskStates SubtaskState { get => _subtaskState; set => _subtaskState = value; }
        public bool isHidden { get => _isHidden; set => _isHidden = value; }
    }
}