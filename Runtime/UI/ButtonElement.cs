using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace URPTemplate.UI
{
    public class ButtonElement : Button
    {
        private static readonly float sizeMax = 1.1f;
        private bool isPointerOn = false;
        private bool isSelected = false;

        public string buttonName = "Data real in Code";
        public Color buttonColor = Color.cyan;

        protected override void Awake()
        {
            var text = GetComponentInChildren<Text>();
            text.text = buttonName;

            colors = new ColorBlock()
            {
                colorMultiplier = 1,
                disabledColor = Color.grey,
                fadeDuration = 0.2f,
                highlightedColor = buttonColor,
                normalColor = Color.white,
                pressedColor = buttonColor,
                selectedColor = buttonColor,
            };
        }

        public bool IsSelected => currentSelectionState == SelectionState.Selected;

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            isPointerOn = true;
            SetLocale();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            isPointerOn = false;
            SetLocale();
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            isSelected = false;
            SetLocale();
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            isSelected = true;
            Debug.Log(buttonName + " is Selected");
            SetLocale();
        }

        private void SetLocale()
        {
            if (isPointerOn || isSelected)
            {
                transform.localScale = Vector3.one * sizeMax;
            }
            else
            {
                transform.localScale = Vector3.one;
            }
        }
    }
}
