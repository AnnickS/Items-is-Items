using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMultipleEffects : Effect
{

    public List<Effect> effects;

    public new void actOn(GameObject item1, GameObject item2)
    {
        foreach(Effect effect in effects)
        {
            effect.actOn(item1, item2);
        }
    }
}
