using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public enum ValidatorType
{
    Name,
    Kind,
    Descriptor,
    //Category
}

[CustomEditor(typeof(Combination))]
public class CombinationManager : Editor
{
    public ValidatorType val1;
    public Validator interactable1;

    [SerializeField]
    public ValidatorType val2;
    [SerializeField]
    public Validator interactable2;

    SerializedProperty validator1;
    SerializedProperty validator2;

    private void OnEnable()
    {
        validator1 = serializedObject.FindProperty("interactable1");
        validator2 = serializedObject.FindProperty("interactable2");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        val1 = (ValidatorType)EditorGUILayout.EnumPopup(val1);
        interactable1 = (Validator)EditorGUILayout.ObjectField(interactable1, typeof(Validator), true);
        val2 = (ValidatorType)EditorGUILayout.EnumPopup(val2);
        interactable2 = (Validator)EditorGUILayout.ObjectField(interactable2, typeof(Validator), true);
        validator2.objectReferenceValue = interactable2;
        //base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();

        
    }
}



/*
[CustomPropertyDrawer(typeof(Validator))]
public class CombinationFAKEDrawer : PropertyDrawer
{
    // public ValidatorType val1;
    //public Validator interactable1;

    //validator2
    //public ValidatorType val2;
    //public Validator interactable2;
    //System.Object t;

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        if (Event.current.type == EventType.Layout)
        {

            //EditorGUI.BeginProperty(position, label, property);
            //EditorGUILayout.BeginHorizontal();

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            //var indent = EditorGUI.indentLevel;
            //EditorGUI.indentLevel = 0;

            // Calculate rects
            var nameRect = new Rect(position.x, position.y, 30, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.ObjectField(nameRect, property);
            //EditorGUILayout.IntField(1);
            //t = EditorGUILayout.ObjectField(interactable1, typeof(DescriptorValidator), true);

            // Set indent back to what it was
            //EditorGUI.indentLevel = indent;

            //EditorGUI.EndProperty();
            //EditorGUILayout.EndHorizontal();
        }
    }
}*/

