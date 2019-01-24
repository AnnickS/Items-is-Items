using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemManagerGUI))]
public class ItemManagerGUISkin : Editor {

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("combinationNew"));
        EditorListHideSize.Show(serializedObject.FindProperty("combinationDisplay"));
        serializedObject.ApplyModifiedProperties();
    }
}
