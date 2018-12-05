using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public static ItemManager Manager;

	// Use this for initialization
	void Start () {
        Manager = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseItem(Collider2D useItem, Collider2D affectedItem)
    {
        string itemUse = useItem.GetComponent<Item>().Tags[0];
        if (itemUse.Equals("RED"))
        {
            changeColor(affectedItem, Color.red);
        } else if (itemUse.Equals("YELLOW"))
        {
            changeColor(affectedItem, Color.yellow);
        }

        Destroy(useItem.gameObject);
    }

    void changeColor(Collider2D affectedItem, Color color)
    {
        affectedItem.GetComponent<SpriteRenderer>().material.color = color;
    }
}
