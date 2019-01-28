using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
//[RequireComponent(typeof(ItemManager))]
public class ItemManagerGUI : MonoBehaviour
{
    public ItemCombinationGUI combinationNew = new ItemCombinationGUI();
    public List<ItemCombinationGUI> combinationDisplay = new List<ItemCombinationGUI>();
    protected List<ItemCombination> bufferDisplay = new List<ItemCombination>();
    //protected ItemManager itemManager;

    void Start()
    {
        //itemManager = GetComponent<ItemManager>();
    }

    void Update()
    {
        /*
        if(itemManager == null)
        {
            itemManager = GetComponent<ItemManager>();
        }*/

        updateModifiedCombinations();
        addAnyNewCombinations();
        createBufferMatchingNewCombination();
        copyBufferToDisplay();
    }

    private void copyBufferToDisplay()
    {
        combinationDisplay.Clear();
        foreach (ItemCombination combination in bufferDisplay)
        {
            combinationDisplay.Add(new ItemCombinationGUI(combination));
        }
    }

    private void createBufferMatchingNewCombination()
    {
        bufferDisplay.Clear();
        List<Combination> combinations = CombinationStorageManager.GetCombinations();
        if (combinationNew == null || combinationNew.isEmpty())
        {
            foreach (Combination combination in combinations)
            {
                if (combination is ItemCombination)
                {
                    bufferDisplay.Add((ItemCombination)combination);
                }
            }
        }
        else
        {
            foreach (Combination combination in combinations)
            {
                if (combination is ItemCombination)
                {
                    ItemCombinationGUI combinationGUI = new ItemCombinationGUI((ItemCombination)combination);

                    if (combinationGUI.contains(combinationNew))
                    {
                        bufferDisplay.Add((ItemCombination)combination);
                    }
                }
            }
        }
    }

    private void addAnyNewCombinations()
    {
        if (combinationNew.isFull())
        {
            addCombination(combinationNew);
            combinationNew = new ItemCombinationGUI();
        }
    }

    private void updateModifiedCombinations()
    {
        for (int index = 0; index < combinationDisplay.Count; index++)
        {
            if(index >= bufferDisplay.Count)
            {
                ItemCombinationGUI displayCombination = combinationDisplay[index];
                addCombination(displayCombination);
            }
            else
            {
                ItemCombinationGUI displayCombination = combinationDisplay[index];
                if (bufferDisplay[index] is ItemCombination)
                {
                    ItemCombination bufferCombination = bufferDisplay[index];

                    if (displayCombination.isPartial())
                    {
                        removeCombination(bufferCombination);
                    }
                    else if (displayCombination.contains(new ItemCombinationGUI(bufferCombination)))
                    {
                        removeCombination(bufferCombination);
                        addCombination(displayCombination);
                    }
                }
            }
        }

    }


    public void addCombination(ItemCombinationGUI combinationNew)
    {
        List<Combination> combinations = CombinationStorageManager.GetCombinations();
        foreach (Combination combination in combinations)
        {
            if (combination is ItemCombination)
            {
                if (new ItemCombinationGUI((ItemCombination)combination).contains(combinationNew))
                {
                    return;
                }
            }
        }

        if (combinationNew.isFull())
        {
            combinations.Add(combinationNew.getCombination());
        }
    }

    public void removeCombination(Combination combination)
    {
        List<Combination> combinations = CombinationStorageManager.GetCombinations();
        if (combinations.Contains(combination))
        {
            combinations.Remove(combination);
        }
    }
}