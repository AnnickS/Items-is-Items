using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    private List<string> items;

	// Use this for initialization
	void Start () {
        items = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addInventoryItem(GameObject item)
    {
        items.Add(item.name);
    }

    public void removeInventoryItem(GameObject item)
    {
        items.Remove(item.name);
    }

    public string getPreviousItem(GameObject current)
    {
        int index = items.FindIndex((s) => s == current.name);
        if (index > 0)
        {
            return items[index-1];
        }
        else
        {
            return null;
        }
    }

    public int getInventoryCount()
    {
        return items.Count;
    }

    public string getLastAdded()
    {
        if(items != null && items.Count > 0)
        {
            return items[items.Count - 1];
        }
        else
        {
            return null;
        }
    }
}
