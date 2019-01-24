using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ItemManager : MonoBehaviour
{
    public static ItemManager Manager;

    public ItemManager()
    {

    }

    List<Combination> combinations = new List<Combination>();

    public List<Combination> GetCombinations()
    {
        return combinations;
    }


    public void UseItem(Collider2D useItemCollider, Collider2D affectedItemCollider)
    {
        Item useItem = useItemCollider.gameObject.GetComponent<Item>();
        if (useItem == null)
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
            if (combination.match(useItem, affectedItem))
            {
                Effect effect = combination.effect;
                effect.actOn(useItem.gameObject, affectedItem.gameObject);
                combined = true;
            }
        }

        if (combined)
        {
            GameObject.Destroy(useItem.gameObject);
        }

    }

    void changeColor(Collider2D affectedItem, Color color)
    {
        affectedItem.GetComponent<SpriteRenderer>().material.color = color;
    }
}
