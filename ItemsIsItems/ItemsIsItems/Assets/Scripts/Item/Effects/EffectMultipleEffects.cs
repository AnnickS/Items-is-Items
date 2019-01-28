using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMultipleEffects : IEffect
{

    public List<IEffect> effects;

    public void Execute(Item item1, Item item2)
    {
        foreach(IEffect effect in effects)
        {
            effect.Execute(item1, item2);
        }
    }
}
