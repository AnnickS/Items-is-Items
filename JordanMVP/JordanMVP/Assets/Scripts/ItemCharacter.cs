using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemCharacter : Item {

    void OnMouseDown()
    {
        Select select = Select.getInstance();

        if(select.isItemSelected())
        {
            GameObject gameObject = select.getSelectedItem().gameObject;

            if(gameObject != this.gameObject)
            {
                ItemDye itemDye = gameObject.GetComponent<ItemDye>();

                if (itemDye != null)
                {
                    select.deselect();
                    itemDye.gameObject.SetActive(false);
                    Destroy(itemDye.gameObject);

                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
            }
        }

        if (ItemSlot.isItemSelected())
        {
            GameObject gameObject = ItemSlot.getSelectedItem().gameObject;

            if (gameObject != this.gameObject)
            {
                ItemDye itemDye = gameObject.GetComponent<ItemDye>();

                if (itemDye != null)
                {
                    ItemSlot.deselect();
                    itemDye.gameObject.SetActive(false);
                    Destroy(itemDye.gameObject);

                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
            }
        }

    }

    public override void usedOn(Item itemUsed)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
