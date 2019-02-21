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

    public override bool IsInitialized()
    {
        foreach (Effect effect in effects)
        {
            if(effect.IsInitialized() == false)
            {
                return false;
            }
        }

        return true;
    }
}
