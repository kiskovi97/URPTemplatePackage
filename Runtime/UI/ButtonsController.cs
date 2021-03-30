using UnityEngine;

namespace URPTemplate.UI
{
    public class ButtonsController : MonoBehaviour
    {
        private ButtonElement[] buttons;

        private void Start()
        {
            buttons = GetComponentsInChildren<ButtonElement>();
            foreach (var button in buttons)
            {
                if (button.IsSelected)
                    return;
            }
            if (buttons.Length > 0)
                buttons[0].Select();
        }
    }
}
