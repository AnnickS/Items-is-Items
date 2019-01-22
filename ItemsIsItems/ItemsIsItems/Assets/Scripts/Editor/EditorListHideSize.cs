using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorListHideSize {

    public static void Show(SerializedProperty list)
    {
        EditorGUILayout.PropertyField(list);
        if(list.isExpanded)
        {
            EditorGUI.indentLevel += 1;
            for (int index = 0; index < list.arraySize; index++)
            {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(index));
            }
            EditorGUI.indentLevel -= 1;
        }
    }
}
