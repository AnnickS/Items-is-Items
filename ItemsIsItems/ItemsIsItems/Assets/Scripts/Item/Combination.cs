using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Combination
{

    public Item useItemType;
    public Item affectedItemType;
    public Effect effect;

    public Combination()
    {

    }

    public Combination(Item useItemType, Item affectedItemType, Effect effect)
    {
        this.useItemType = useItemType;
        this.affectedItemType = affectedItemType;
        this.effect = effect;
    }

    public bool match(Item useItem, Item affectedItem)
    {
        bool useItemSame = useItemType.GetType().IsAssignableFrom(useItem.GetType());
        bool affectedItemSame = affectedItemType.GetType().IsAssignableFrom(affectedItem.GetType());

        return (useItemSame && affectedItemSame);
    }

    public Effect getEffect()
    {
        return effect;
    }
}

