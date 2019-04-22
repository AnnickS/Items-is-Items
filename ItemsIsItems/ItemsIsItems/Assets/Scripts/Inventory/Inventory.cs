using System;
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

    public virtual void AddItemAt(Item item, int index)
    {
        index = Math.Max(0, Math.Min(index, items.Count));
        items.Insert(index, item);
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

    public int ItemCount()
    {
        return items.Count;
    }

    public List<String> GetAllItemNames()
    {
        List<String> itemNames = new List<string>();
        foreach(Item item in items)
        {
            itemNames.Add(item.name);
        }
        return itemNames;
    }
}
