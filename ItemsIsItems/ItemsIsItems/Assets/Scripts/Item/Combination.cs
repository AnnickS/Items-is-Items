using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination
{

    Type useItemType;
    Type affectedItemType;
    Effect effect;

    public Combination(Type useItemType, Type affectedItemType, Effect effect)
    {
        this.useItemType = useItemType;
        this.affectedItemType = affectedItemType;
        this.effect = effect;
    }

    public bool match(Item useItem, Item affectedItem)
    {
        bool useItemSame = useItemType.IsAssignableFrom(useItem.GetType());
        bool affectedItemSame = affectedItemType.IsAssignableFrom(affectedItem.GetType());

        return (useItemSame && affectedItemSame);
    }

    public Effect getEffect()
    {
        return effect;
    }
}

