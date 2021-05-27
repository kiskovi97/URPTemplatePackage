using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace URPTemplate.UI
{
    [RequireComponent(typeof(Text))]
    class TextFontLoader : MonoBehaviour
    {
        void Awake()
        {
            var text = GetComponent<Text>();
            var settings = URPTemplateSettings.GetOrCreateSettings();
            text.font = settings.MenuFont;
        }
    }
}

