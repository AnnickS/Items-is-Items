using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
enum ValidatorType
{
    Item,
    Descriptor
}

//[CustomPropertyDrawer(typeof(Validator))]
public class ValidatorDrawer : PropertyDrawer {

    SerializedProperty descriptor;
    
    ValidatorType selectedType = ValidatorType.Descriptor;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 32;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        //base.OnGUI(position, property, label);
        position.height = 16;

        bool typeChoosen = property.objectReferenceValue != null;
        if (typeChoosen)
        {
            if (property.objectReferenceValue is ItemValidator)
            {
                selectedType = ValidatorType.Item;
            }
            else if (property.objectReferenceValue is DescriptorValidator)
            {
                selectedType = ValidatorType.Descriptor;
            }
            else
            {
                Debug.LogError(property.objectReferenceValue.name + "'s ValidatorType is not handled!");
            }
        }

        int dropdownWidth = 10;
        //EditorGUI.PropertyField(position, property);
        if (EditorGUI.DropdownButton(position, new GUIContent(selectedType.ToString()), FocusType.Passive))
        {
            GenericMenu menu = new GenericMenu();
            foreach (ValidatorType type in Enum.GetValues(typeof(ValidatorType)))
            {
                menu.AddItem(new GUIContent(type.ToString()), false, () => selectedType = type);
            }
            menu.DropDown(new Rect(position.x, position.y, dropdownWidth, position.height));
        }
        //EditorGUI.DropdownButton(position, menu, FocusType.Passive);
        position.y += 16;
        if (typeChoosen)
        {
            SerializedObject SO = new SerializedObject(property.objectReferenceValue);
            switch (selectedType)
            {
                case ValidatorType.Item:
                    break;
                case ValidatorType.Descriptor:
                    break;
            }
        }
        
        if (property.objectReferenceValue != null)
        {
            SerializedObject SO = new SerializedObject(property.objectReferenceValue);
            SO.Update();
            if (property.objectReferenceValue is DescriptorValidator)
            {
                descriptor = SO.FindProperty("descriptor");
                EditorGUI.PropertyField(position, descriptor);
                SO.ApplyModifiedProperties();
                //return;
            }
        }
        //base.OnGUI(position, property, label);

        //if(GUI.changed)
    }
}
*/