using UnityEngine;
using UnityEngine.InputSystem;
using URPTemplate.Core;

namespace URPTemplate.UI
{
    public class ScreenController: MonoBehaviour, Controls.INavigateActions
    {
        private void Start()
        {
            InputHandler.SetCallback(this);
        }

        private void OnDestroy()
        {
            InputHandler.RemoveCallback(this);
        }

        public virtual void ExitClicked()
        {
            Debug.Log("Exit Clicked");
            UIScreenManager.Exit();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            ExitClicked();
        }
    }
}
