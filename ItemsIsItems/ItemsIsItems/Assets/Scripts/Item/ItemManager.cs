using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public static ItemManager Manager;

	// Use this for initialization
	void Start () {
        Manager = this;
        combinations.Add(new Combination(typeof(Item), typeof(Item), new EffectChangeColor()));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private List<Combination> combinations = new List<Combination>();
    public void UseItem(Collider2D useItemCollider, Collider2D affectedItemCollider)
    {
        Item useItem = useItemCollider.gameObject.GetComponent<Item>();
        if(useItem == null)
        {
            return;
        }

        Item affectedItem = affectedItemCollider.gameObject.GetComponent<Item>();
        if (affectedItem == null)
        {
            return;
        }

        bool combined = false;
        foreach (Combination combination in combinations)
        {
            if(combination.match(useItem, affectedItem))
            {
                Effect effect = combination.getEffect();
                effect.actOn(useItem.gameObject, affectedItem.gameObject);
                combined = true;
            }
        }

        if(combined)
        {
            Destroy(useItem.gameObject);
        }

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
