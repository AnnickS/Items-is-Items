using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ItemManagerGUI : MonoBehaviour
{
    public ItemManager itemManager = new ItemManager();
    public Combination combinationNew = new Combination();
    public List<Combination> combinationDisplay = new List<Combination>();

    void Awake()
    {
        Debug.Log("Editor causes this Awake");
    }

    void Update()
    {

        List<Combination> combinations = itemManager.GetCombinations();


        if (combinationNew.isFull())
        {
            itemManager.addCombination(combinationNew);
            combinationNew = new Combination();
        }

        foreach (Combination combination in combinations)
        {
            if ( ! combinations.Contains(combination))
            {
                itemManager.addCombination(combination);
            }
        }

        combinationDisplay.Clear();
        //combinationDisplay.Add(new Combination());


        if (combinationNew == null || combinationNew.isEmpty())
        {
            foreach (Combination combination in combinations)
            {
                combinationDisplay.Add(combination);
            }
        }
        else
        {
            foreach (Combination combination in combinations)
            {
                if(combination.contains(combinationNew))
                {
                    combinationDisplay.Add(combination);
                }
            }
        }



    }
}