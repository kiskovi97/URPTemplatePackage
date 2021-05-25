using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace URPTemplate.UI
{
    public class ButtonsController : MonoBehaviour
    {

        public GameObject firstButton;
        private void Start()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButton);
        }

        private void Update()
        {
           
            if (Gamepad.all.Count > 0)
            {
                if (EventSystem.current.currentSelectedGameObject == null)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(firstButton);
                }
            }
        }
    }
}
