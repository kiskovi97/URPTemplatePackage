using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace URPTemplate.Core
{
    public class InputHandler : MonoBehaviour, Controls.INavigateActions
    {
        private static InputHandler Instance;
        private Controls inputActions;
        private static List<Controls.INavigateActions> subscribers = new List<Controls.INavigateActions>();


        public static void SetCallback(Controls.INavigateActions characterActions)
        {
            subscribers.Add(characterActions);
            Debug.Log("SetCallback");
        }

        public static void RemoveCallback(Controls.INavigateActions characterActions)
        {
            subscribers.Remove(characterActions);
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                inputActions = new Controls();
                inputActions.Enable();
                inputActions.Navigate.SetCallbacks(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                foreach (var subscriber in subscribers)
                {
                    subscriber.OnCancel(context);
                }
        }
    }
}
