using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;


[CreateAssetMenu(menuName = "Effects/Multi")]
public class EffectMultipleEffects : Effect
{

    public List<Effect> effects = new List<Effect>();

    public override void Execute(Item item1, Item item2)
    {
        foreach(Effect effect in effects)
        {
            effect.Execute(item1, item2);
        }
    }

    public override Effect LoadArgs(System.Object[] args)
    {
        Effect[] effects = (Effect[])args;
        Debug.Log(effects.Length);
        for(int i = 0; i < effects.Length; i++)
        {
            this.effects.Add(effects[i]);
        }
        return this;
    }

    public override void ToSafeFormat(StringBuilder stringBuilder)
    {
        stringBuilder.Append("{Multi ");
        foreach (Effect effect in effects)
        {
            effect.ToSafeFormat(stringBuilder);
        }
        stringBuilder.Append("}");
    }
}
