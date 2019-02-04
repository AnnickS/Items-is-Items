using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventory : Inventory {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        //Check the provided Collider2D parameter other to see if it is tagged "Player", if it is...
        if (!item.Equals(null) && !Contains(item))
        {
            //Item is added to inventory
            this.AddItem(item);
            item.gameObject.SetActive(false);
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
