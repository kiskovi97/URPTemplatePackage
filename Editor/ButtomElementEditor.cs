using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using URPTemplate.UI;

[CustomEditor(typeof(ButtonElement))]
public class ButtomElementEditor : Editor
{
    SerializedProperty m_OnClick;
    private void OnEnable()
    {
        m_OnClick = this.serializedObject.FindProperty("m_OnClick");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        ButtonElement element = (ButtonElement)target;

        var prev = element.buttonName;
        var prev2 = element.buttonColor;
        element.buttonName = EditorGUILayout.TextField("ButtonName", element.buttonName);

        element.buttonColor = EditorGUILayout.ColorField("Color", element.buttonColor);
        
        if (m_OnClick != null)
        {
            EditorGUILayout.PropertyField(m_OnClick);

            serializedObject.ApplyModifiedProperties();
        }

        if (prev != element.buttonName || prev2 != element.buttonColor)
            EditorUtility.SetDirty(target);
    }
}
