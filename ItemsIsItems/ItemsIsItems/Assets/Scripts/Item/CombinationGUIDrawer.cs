using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CombinationGUI))]
public class CombinationDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        int spacing = (int)(position.width)/3;
        Rect amountRect = new Rect(position.x + spacing*0 + 0, position.y, spacing, position.height);
        Rect unitRect = new Rect(position.x + spacing*1 + 3, position.y, spacing, position.height);
        Rect nameRect = new Rect(position.x + spacing*2 + 6, position.y, spacing, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("useItemType"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("affectedItemType"), GUIContent.none);
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("effect"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;
        //*/

        EditorGUI.EndProperty();
    }
}
