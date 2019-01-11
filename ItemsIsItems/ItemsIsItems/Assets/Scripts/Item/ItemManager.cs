using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public static ItemManager Manager;

	// Use this for initialization
	void Start () {
        Manager = this;
        combinations.Add(new Combination("ItemFlower", "Item", new EffectChangeColor()));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private List<Combination> combinations = new List<Combination>();
    public void UseItem(Collider2D useItem, Collider2D affectedItem)
    {
        List<string> itemUseTags = useItem.GetComponent<Item>().Tags;
        List<string> affectedItemTags = useItem.GetComponent<Item>().Tags;

        foreach(Combination combination in combinations)
        {
            if(combination.match(itemUseTags, affectedItemTags))
            {
                Effect effect = combination.getEffect();
                effect.actOn(useItem.gameObject, affectedItem.gameObject);
            }
        }

        Destroy(useItem.gameObject);

        /*
        string itemUse = useItem.GetComponent<Item>().Tags[0];
        if (itemUse.Equals("RED"))
        {
            changeColor(affectedItem, Color.red);
        } else if (itemUse.Equals("YELLOW"))
        {
            changeColor(affectedItem, Color.yellow);
        }
        
        Destroy(useItem.gameObject);
        //*/

    }

    void changeColor(Collider2D affectedItem, Color color)
    {
        affectedItem.GetComponent<SpriteRenderer>().material.color = color;
    }
}
