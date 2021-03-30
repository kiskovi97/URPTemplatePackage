using Assets;
using UnityEngine;
using UnityEngine.InputSystem;

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

        public void ExitClicked()
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
