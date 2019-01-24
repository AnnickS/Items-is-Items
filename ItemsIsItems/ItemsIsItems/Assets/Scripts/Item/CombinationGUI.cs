using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CombinationGUI
{

    public Item useItemType;
    public Item affectedItemType;
    public Effect effect;

    public CombinationGUI()
    {

    }

    public CombinationGUI(Item useItemType, Item affectedItemType, Effect effect)
    {
        this.useItemType = useItemType;
        this.affectedItemType = affectedItemType;
        this.effect = effect;
    }

    public CombinationGUI(Combination combination)
    {
        useItemType = combination.useItemType;
        affectedItemType = combination.affectedItemType;
        effect = combination.effect;
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

    public bool isEmpty()
    {
        bool emptyUseItem = (useItemType == null);
        bool emptyAffectedItemType = (affectedItemType == null);
        bool emptyEffect = (effect == null);

        return (emptyUseItem && emptyAffectedItemType && emptyEffect);
    }

    public bool isPartial()
    {
        return (!isEmpty() && !isFull());
    }

    public bool isFull()
    {
        bool emptyUseItem = (useItemType == null);
        bool emptyAffectedItemType = (affectedItemType == null);
        bool emptyEffect = (effect == null);

        return !(emptyUseItem || emptyAffectedItemType || emptyEffect);
    }

    internal bool contains(CombinationGUI combinationNew)
    {
        if (this.isEmpty() || this.isPartial())
        {
            return false;
        }

        bool sameuseItemType = false;
        bool sameaffectedItemType = false;
        bool sameeffect = false;

        if (combinationNew.useItemType != null)
        {
            sameuseItemType = (useItemType.GetType() == combinationNew.useItemType.GetType());
        }
        else
        {
            sameuseItemType = true;
        }

        if (combinationNew.affectedItemType != null)
        {
            sameaffectedItemType = (affectedItemType.GetType() == combinationNew.affectedItemType.GetType());
        }
        else
        {
            sameaffectedItemType = true;
        }

        if (combinationNew.effect != null)
        {
            sameeffect = (effect.GetType() == combinationNew.effect.GetType());
        }
        else
        {
            sameeffect = true;
        }



        return (sameuseItemType && sameaffectedItemType && sameeffect);
    }

    internal Combination getCombination()
    {
        return new Combination(useItemType, affectedItemType, effect);
    }
}

