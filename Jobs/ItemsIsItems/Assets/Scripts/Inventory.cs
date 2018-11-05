using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public PlayerController player {get; set;}

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    public abstract void Open();
    public abstract void Close();

    public virtual void AddItem(Item item)
    {
        items.Add(item);
    }

    public virtual void removeItem(Item item)
    {
        items.Remove(item);
    }


    public bool Contains(Item item)
    {
        return items.Contains(item);
    }
}
