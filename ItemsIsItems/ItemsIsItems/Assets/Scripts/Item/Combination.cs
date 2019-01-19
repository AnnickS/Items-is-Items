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
    public Item item1;
    public Item item2;

    public ItemCombination(Item item1, Item item2, IEffect effect)
    {
        this.item1 = item1;
        this.item2 = item2;
        this.effect = effect;
    }

    public override bool Match(Item item1, Item item2)
    {
        return (item1.NameEquals(this.item1) && item2.NameEquals(this.item2));
    }
}

public class GeneralItemCombination : Combination
{
    public Item item;
    public Descriptor tag;

    public GeneralItemCombination(Item item, Descriptor tag, IEffect effect)
    {
        this.item = item;
        this.tag = tag;
        this.effect = effect;
    }

    public override bool Match(Item item1, Item item2)
    {
        return (item1.NameEquals(this.item) && item2.HasDescriptor(this.tag));
    }
}

