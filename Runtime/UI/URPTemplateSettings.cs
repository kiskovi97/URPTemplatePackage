using UnityEngine;

namespace URPTemplate.UI
{
    public class URPTemplateSettings : ScriptableObject
    {
        public const string k_URPTemplateSettingsPath = "Assets/Resources/" + k_URPTemplateResources + ".asset";
        private const string k_URPTemplateResources = "URPTemplateSettings";

        [SerializeField]
        public Sprite m_Background;
        public Sprite BackgroundSprite => m_Background;

        [SerializeField]
        public float m_SizeRatio;
        public float AspectRatio => m_SizeRatio;

        [SerializeField]
        public Font m_Font;
        public Font MenuFont => m_Font;

        public static URPTemplateSettings GetOrCreateSettings()
        {
            var settings = Resources.Load<URPTemplateSettings>(k_URPTemplateResources);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<URPTemplateSettings>();
                settings.m_Background = null;
                settings.m_SizeRatio = 4;
                settings.m_Font = null;
            }
            return settings;
        }
    }

    // Register a SettingsProvider using IMGUI for the drawing framework:
    
}