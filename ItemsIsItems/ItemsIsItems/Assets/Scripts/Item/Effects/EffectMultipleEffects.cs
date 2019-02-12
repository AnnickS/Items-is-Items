using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class EffectMultipleEffects : IEffect
{

    public List<IEffect> effects = new List<IEffect>();

    public void Execute(Item item1, Item item2)
    {
        foreach(IEffect effect in effects)
        {
            effect.Execute(item1, item2);
        }
    }

    public IEffect LoadArgs(System.Object[] args)
    {
        IEffect[] effects = (IEffect[])args;
        Debug.Log(effects.Length);
        for(int i = 0; i < effects.Length; i++)
        {
            this.effects.Add(effects[i]);
        }
        return this;
    }

    public void ToSafeFormat(StringBuilder stringBuilder)
    {
        stringBuilder.Append("{Multi ");
        foreach (IEffect effect in effects)
        {
            effect.ToSafeFormat(stringBuilder);
        }
        stringBuilder.Append("}");
    }
}
