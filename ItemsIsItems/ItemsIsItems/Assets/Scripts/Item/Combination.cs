using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination
{

    string tag1;
    string tag2;
    Effect effect;

    public Combination(string tag1, string tag2, Effect effect)
    {
        this.tag1 = tag1;
        this.tag2 = tag2;
        this.effect = effect;
    }

    public bool match(List<string> tags1, List<string> tags2)
    {
        return true;
    }

    public Effect getEffect()
    {
        return effect;
    }
}

