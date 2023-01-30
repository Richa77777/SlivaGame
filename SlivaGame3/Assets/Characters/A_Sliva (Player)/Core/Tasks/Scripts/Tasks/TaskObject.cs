using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tasks
{
    public abstract class TaskObject : ScriptableObject
    {
        [SerializeField] protected string _taskName;

        [Space(10f)]

        [TextArea(10, 15)] [SerializeField] protected string _taskDescription;

        [Space(25f)]

        [SerializeField] protected List<Subtask> _subtasks = new List<Subtask>();

        public string TaskName { get => _taskName; }
        public string TaskDescription { get => _taskDescription; }
        public List<Subtask> Subtasks { get => _subtasks; }
    }

    [System.Serializable]
    public struct Subtask
    {
        [SerializeField] private string _subtaskText;
        [SerializeField] private bool _isCompleted;

        public string SubtaskText { get => _subtaskText; }
        public bool isCompleted { get => _isCompleted; }

        public void SetSubtaskText(string text)
        {
            _subtaskText = text;
        }

        public void Completed()
        {
            _isCompleted = true;
        }
    }
}