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