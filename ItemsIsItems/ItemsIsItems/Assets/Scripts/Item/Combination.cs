using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combination
{
    public IEffect effect;

    public abstract bool Match(Item item1, Item item2);
    
    public IEffect GetEffect()
    {
        return effect;
    }
}

public class ItemCombination : Combination
{ 
    public String item1Name;
    public String item2Name;

    public ItemCombination(String item1Name, String item2Name, IEffect effect)
    {
        this.item1Name = item1Name;
        this.item2Name = item2Name;
        this.effect = effect;
    }

    public override bool Match(Item item1, Item item2)
    {
        return (item1.name == item1Name && item2.name == item2Name);
    }
}

public class GeneralItemCombination : Combination
{
    public String itemName;
    public Descriptor tag;

    public GeneralItemCombination(String itemName, Descriptor tag, IEffect effect)
    {
        this.itemName = itemName;
        this.tag = tag;
        this.effect = effect;
    }

    public override bool Match(Item item1, Item item2)
    {
        return (item1.name == itemName && item2.HasDescriptor(this.tag));
    }
}

