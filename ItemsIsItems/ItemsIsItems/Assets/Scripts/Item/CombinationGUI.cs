﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemCombinationGUI
{

    public String useItemType;
    public String affectedItemType;
    public IEffect effect;

    public ItemCombinationGUI()
    {

    }

    public ItemCombinationGUI(String useItemType, String affectedItemType, IEffect effect)
    {
        this.useItemType = useItemType;
        this.affectedItemType = affectedItemType;
        this.effect = effect;
    }

    public ItemCombinationGUI(ItemCombination combination)
    {
        useItemType = combination.item1Name;
        affectedItemType = combination.item1Name;
        effect = combination.effect;
    }

    public bool match(Item useItem, Item affectedItem)
    {
        /*
        bool useItemSame = useItemType.GetType().IsAssignableFrom(useItem.GetType());
        bool affectedItemSame = affectedItemType.GetType().IsAssignableFrom(affectedItem.GetType());
        */
        bool useItemSame = useItemType == useItem.name;
        bool affectedItemSame = affectedItemType == affectedItem.name;

        return (useItemSame && affectedItemSame);
    }

    public IEffect getEffect()
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

    internal bool contains(ItemCombinationGUI combinationNew)
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
        return new ItemCombination(useItemType, affectedItemType, effect);
    }
}

