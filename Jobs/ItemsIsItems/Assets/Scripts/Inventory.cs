using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
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
        items.Add(item);
    }

    public virtual void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public virtual bool Contains(Item item)
    {
        return items.Contains(item);
    }
}
