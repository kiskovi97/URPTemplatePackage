using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using URPTemplate.UI;

namespace kiskovi.URPTemplate.Editor
{
    public static class URPTemplateSettingsIMGUIRegister
    {
        [SettingsProvider]
        public static SettingsProvider CreateURPTemplateSettingsProvider()
        {
            // First parameter is the path in the Settings window.
            // Second parameter is the scope of this setting: it only appears in the Project Settings window.
            var provider = new SettingsProvider("Project/MyCustomIMGUISettings", SettingsScope.Project)
            {
                // By default the last token of the path is used as display name if no label is provided.
                label = "URP Template Settings",
                // Create the SettingsProvider and initialize its drawing (IMGUI) function in place:
                guiHandler = (searchContext) =>
                {
                    var settings = new SerializedObject(GetOrCreateSettings());

                    EditorGUILayout.PropertyField(settings.FindProperty("m_Background"), new GUIContent("Background Image"));
                    EditorGUILayout.PropertyField(settings.FindProperty("m_SizeRatio"), new GUIContent("Size Ratio"));
                    EditorGUILayout.PropertyField(settings.FindProperty("m_Font"), new GUIContent("Menu Font"));
                    settings.ApplyModifiedProperties();
                },

                inspectorUpdateHandler = () =>
                {

                },


                // Populate the search keywords to enable smart search filtering and label highlighting:
                keywords = new HashSet<string>(new[] { "Number", "Some String" })
            };

            return provider;
        }

        public static URPTemplateSettings GetOrCreateSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<URPTemplateSettings>(URPTemplateSettings.k_URPTemplateSettingsPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<URPTemplateSettings>();
                settings.m_Background = null;
                settings.m_SizeRatio = 4;
                settings.m_Font = null;
                AssetDatabase.CreateAsset(settings, URPTemplateSettings.k_URPTemplateSettingsPath);
                AssetDatabase.SaveAssets();
            }
            return settings;
        }
    }
}
