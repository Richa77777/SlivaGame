using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class DialogButton : MonoBehaviour
    {
        private Dialog _currentDialog;
        public Dialog CurrentDialog { get => _currentDialog; }

        public void SetCurrentDialog(Dialog dialog)
        {
            _currentDialog = dialog;
        }

        public void StartDialog()
        {
            _currentDialog.StartDialog();
        }
    }
}
