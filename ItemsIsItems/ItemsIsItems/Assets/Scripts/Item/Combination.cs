using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Combination/Combination")]
public class Combination : ScriptableObject
{
    public Validator itemValidator1;
    public Validator itemValidator2;
    public Effect effect;

    private void OnAwake()
    {
        if (itemValidator1 == null)
        {
            Debug.LogError("Combination, " + name + ", is missing itemValidator1!");
        }
        if(itemValidator2 == null)
        {
            Debug.LogError("Combination, " + name + ", is missing itemValidator2!");
        }
        if(effect == null)
        {
            Debug.LogError("Combination, " + name + ", is missing an effect!");
        }
    }

    public Combination(Validator itemValidator1, Validator itemValidator2, Effect effect)
    {
        this.itemValidator1 = itemValidator1;
        this.itemValidator2 = itemValidator2;
        this.effect = effect;
    }

    public bool Match(Item item1, Item item2)
    {
        return (itemValidator1.ItemMatch(item1) && itemValidator2.ItemMatch(item2));
    }
    
    public Effect GetEffect()
    {
        return effect;
    }

    public override string ToString()
    {
        return itemValidator1.GetName() + " + " + itemValidator2.GetName();
    }
}