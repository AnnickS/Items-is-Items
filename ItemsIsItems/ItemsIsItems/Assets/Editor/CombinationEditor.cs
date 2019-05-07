using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**/
[CustomEditor(typeof(Combination))]
public class CombinationEditor : Editor
{
    SerializedProperty itemValidator1;
    SerializedProperty itemValidator2;
    SerializedProperty effect;

    GUIStyle errorStyle = new GUIStyle();

    void OnEnable()
    {
        errorStyle.normal.textColor = Color.red;
        itemValidator1 = serializedObject.FindProperty("itemValidator1");
        itemValidator2 = serializedObject.FindProperty("itemValidator2");
        effect = serializedObject.FindProperty("effect");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUIStyle style = GUIStyle.none;

        EditorGUILayout.BeginHorizontal();
        if(itemValidator1.objectReferenceValue == null || (itemValidator1.objectReferenceValue as Validator).IsInitialized() == false)
        {
            style = errorStyle;
            GUI.contentColor = Color.red;
        }
        GUILayout.Label("ItemValidator1", style);
        EditorGUILayout.ObjectField(itemValidator1, typeof(Validator), GUIContent.none);
        EditorGUILayout.EndHorizontal();
        GUI.contentColor = Color.white;
        style = GUIStyle.none;

        EditorGUILayout.BeginHorizontal();
        if (itemValidator2.objectReferenceValue == null || (itemValidator2.objectReferenceValue as Validator).IsInitialized() == false)
        {
            style = errorStyle;
            GUI.contentColor = Color.red;
        }
        GUILayout.Label("ItemValidator2", style);
        EditorGUILayout.ObjectField(itemValidator2, typeof(Validator), GUIContent.none);
        EditorGUILayout.EndHorizontal();
        GUI.contentColor = Color.white;
        style = GUIStyle.none;

        EditorGUILayout.BeginHorizontal();
        if (effect.objectReferenceValue == null || (effect.objectReferenceValue as Effect).IsInitialized() == false)
        {
            style = errorStyle;
            GUI.contentColor = Color.red;
        }
        GUILayout.Label("Effect", style);
        EditorGUILayout.ObjectField(effect, typeof(Effect), GUIContent.none);
        EditorGUILayout.EndHorizontal();
        GUI.contentColor = Color.white;
        style = GUIStyle.none;

        serializedObject.ApplyModifiedProperties();
    }
}
/**/
