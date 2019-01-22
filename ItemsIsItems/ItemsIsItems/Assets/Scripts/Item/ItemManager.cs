using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
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
                Effect effect = combination.getEffect();
                effect.actOn(useItem.gameObject, affectedItem.gameObject);
                combined = true;
            }
        }

        if (combined)
        {
            GameObject.Destroy(useItem.gameObject);
        }

    }

    public void removeCombination(Combination combination)
    {
        if (combinations.Contains(combination))
        {
            combinations.Remove(combination);
        }
    }

    public void addCombination(Combination combinationNew)
    {
        foreach(Combination combination in combinations)
        {
            if(combination.contains(combinationNew))
            {
                return;
            }
        }

        if (combinationNew.isFull())
        {
            combinations.Add(combinationNew);
        }
    }

    void changeColor(Collider2D affectedItem, Color color)
    {
        affectedItem.GetComponent<SpriteRenderer>().material.color = color;
    }
}
