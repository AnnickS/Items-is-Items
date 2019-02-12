using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventory : Inventory {
    Item OverItem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(OverItem != null && OverItem.isPickupable)
        {
            //Item is added to inventory
            OverItem.gameObject.SetActive(false);
            this.AddItem(OverItem);
            OverItem = null;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        //Check the provided Collider2D parameter other to see if it is tagged "Player", if it is...
        if (item != null && !Contains(item) && item.isPickupable)
        {
            //Item is added to inventory
            item.gameObject.SetActive(false);
            this.AddItem(item);
        }
        else if(item != null && !Contains(item) && !item.isPickupable)
        {
            OverItem = item;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null && item.Equals(OverItem))
        {
            OverItem = null;
        }
    }

    public override void Open()
    {
        return;
    }

    public override void Close()
    {
        return;
    }
}
