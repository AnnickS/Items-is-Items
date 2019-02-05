﻿using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;

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

    public IEffect LoadArgs(System.Object[] args)
    {
        IEffect[] effects = (IEffect[])args;
        for(int i = 0; i < effects.Length; i++)
        {
            this.effects.Add(effects[i]);
        }
        return this;
    }
}
