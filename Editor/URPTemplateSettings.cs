using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class URPTemplateSettings : ScriptableObject
{
    public const string k_URPTemplateSettingsPath = "Assets/URPTemplateSettings.asset";

    [SerializeField]
    private Sprite m_Background;
    public Sprite BackgroundSprite => m_Background;

    [SerializeField]
    private float m_SizeRatio;
    public float AspectRatio => m_SizeRatio;

    [SerializeField]
    private Font m_Font;
    public Font MenuFont => m_Font;

    public static URPTemplateSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<URPTemplateSettings>(k_URPTemplateSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<URPTemplateSettings>();
            settings.m_Background = null;
            settings.m_SizeRatio = 4;
            settings.m_Font = null;
            AssetDatabase.CreateAsset(settings, k_URPTemplateSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }

    public static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
}

// Register a SettingsProvider using IMGUI for the drawing framework:
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
                var settings = URPTemplateSettings.GetSerializedSettings();
                EditorGUILayout.PropertyField(settings.FindProperty("m_Background"), new GUIContent("Background Image"));
                EditorGUILayout.PropertyField(settings.FindProperty("m_SizeRatio"), new GUIContent("Size Ratio"));
                EditorGUILayout.PropertyField(settings.FindProperty("m_Font"), new GUIContent("Menu Font"));
                settings.ApplyModifiedProperties();
            },

            inspectorUpdateHandler = () => {

            },


            // Populate the search keywords to enable smart search filtering and label highlighting:
            keywords = new HashSet<string>(new[] { "Number", "Some String" })
        };

        return provider;
    }
}