using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Combination/Combination")]
public class Combination : ScriptableObject
{
    public Validator interactable1;
    public Validator interactable2;
    public IEffect effect;

    public Combination(Validator interactable1, Validator interactable2, IEffect effect)
    {
        this.interactable1 = interactable1;
        this.interactable2 = interactable2;
        this.effect = effect;
    }

    public bool Match(Item item1, Item item2)
    {
        return (interactable1.ItemMatch(item1) && interactable2.ItemMatch(item2));
    }
    
    public IEffect GetEffect()
    {
        return effect;
    }

    public StringBuilder ToSafeFormat(StringBuilder stringBuilder)
    {
        interactable1.ToSafeFormat(stringBuilder);
        stringBuilder.Append(" ");
        interactable2.ToSafeFormat(stringBuilder);
        stringBuilder.Append(" ");
        effect.ToSafeFormat(stringBuilder);
        stringBuilder.AppendLine();
        return stringBuilder;

    }
}


public enum ValidatorType
{
    Name,
    Kind,
    Descriptor,
    //Category
}

[CustomPropertyDrawer(typeof(Validator))]
public class CombinationFAKEDrawer : PropertyDrawer
{
   // public ValidatorType val1;
    public Validator interactable1;

    //validator2
    //public ValidatorType val2;
    //public Validator interactable2;

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        //if (Event.current.type == EventType.Repaint)
        //{

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
        //EditorGUI.ObjectField(nameRect, typeof(DescriptorValidator));
            //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("interactable1"), GUIContent.none);
            EditorGUILayout.ObjectField(interactable1, typeof(DescriptorValidator), true);

            // Set indent back to what it was
            //EditorGUI.indentLevel = indent;

            //EditorGUI.EndProperty();
            //EditorGUILayout.EndHorizontal();
       // }
    }
}
