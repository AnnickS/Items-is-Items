﻿using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField]
    protected List<Item> items = new List<Item>();
    protected GameObject belongsTo;

    protected virtual void Start()
    {
        this.belongsTo = gameObject;
    }

    public abstract void Open();
    public abstract void Close();

    public virtual void AddItem(Item item)
    {
        items.Insert(0, item);
    }

    public virtual void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public virtual void RemoveAll()
    {
        items.RemoveAll((item) => { item.Drop(); return true; });
    }


    public virtual bool Contains(Item item)
    {
        return items.Contains(item);
    }
}
