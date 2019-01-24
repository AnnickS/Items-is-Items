using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(ItemManager))]
public class ItemManagerGUI : MonoBehaviour
{
    public Combination combinationNew = new Combination();
    public List<Combination> combinationDisplay = new List<Combination>();
    protected List<Combination> bufferDisplay = new List<Combination>();
    protected ItemManager itemManager;

    void Start()
    {
        itemManager = GetComponent<ItemManager>();
    }

    void Update()
    {
        if(itemManager == null)
        {
            itemManager = GetComponent<ItemManager>();
        }

        updateModifiedCombinations();
        addAnyNewCombinations();
        createBufferMatchingNewCombination();
        copyBufferToDisplay();
    }

    private void copyBufferToDisplay()
    {
        combinationDisplay.Clear();
        foreach (Combination combination in bufferDisplay)
        {
            combinationDisplay.Add(combination);
        }
    }

    private void createBufferMatchingNewCombination()
    {
        bufferDisplay.Clear();
        List<Combination> combinations = itemManager.GetCombinations();
        if (combinationNew == null || combinationNew.isEmpty())
        {
            foreach (Combination combination in combinations)
            {
                bufferDisplay.Add(combination);
            }
        }
        else
        {
            foreach (Combination combination in combinations)
            {
                if (combination.contains(combinationNew))
                {
                    bufferDisplay.Add(combination);
                }
            }
        }
    }

    private void addAnyNewCombinations()
    {
        if (combinationNew.isFull())
        {
            itemManager.addCombination(combinationNew);
            combinationNew = new Combination();
        }
    }

    private void updateModifiedCombinations()
    {
        for (int index = 0; index < combinationDisplay.Count; index++)
        {
            if(index >= bufferDisplay.Count)
            {
                Combination displayCombination = combinationDisplay[index];
                itemManager.addCombination(displayCombination);
            }
            else
            {
                Combination displayCombination = combinationDisplay[index];
                Combination bufferCombination = bufferDisplay[index];

                if (displayCombination.isPartial())
                {
                    itemManager.removeCombination(bufferCombination);
                }
                else if (displayCombination != bufferCombination)
                {
                    itemManager.removeCombination(bufferCombination);
                    itemManager.addCombination(displayCombination);
                }
            }
        }

    }
}