using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(ItemManager))]
public class ItemManagerGUI : MonoBehaviour
{
    public CombinationGUI combinationNew = new CombinationGUI();
    public List<CombinationGUI> combinationDisplay = new List<CombinationGUI>();
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
            combinationDisplay.Add(new CombinationGUI(combination));
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
                CombinationGUI combinationGUI = new CombinationGUI(combination);

                if (combinationGUI.contains(combinationNew))
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
            addCombination(combinationNew);
            combinationNew = new CombinationGUI();
        }
    }

    private void updateModifiedCombinations()
    {
        for (int index = 0; index < combinationDisplay.Count; index++)
        {
            if(index >= bufferDisplay.Count)
            {
                CombinationGUI displayCombination = combinationDisplay[index];
                addCombination(displayCombination);
            }
            else
            {
                CombinationGUI displayCombination = combinationDisplay[index];
                Combination bufferCombination = bufferDisplay[index];

                if (displayCombination.isPartial())
                {
                    removeCombination(bufferCombination);
                }
                else if (displayCombination.contains(new CombinationGUI(bufferCombination)))
                {
                    removeCombination(bufferCombination);
                    addCombination(displayCombination);
                }
            }
        }

    }


    public void addCombination(CombinationGUI combinationNew)
    {
        List<Combination> combinations = itemManager.GetCombinations();
        foreach (Combination combination in combinations)
        {
            if (new CombinationGUI(combination).contains(combinationNew))
            {
                return;
            }
        }

        if (combinationNew.isFull())
        {
            combinations.Add(combinationNew.getCombination());
        }
    }

    public void removeCombination(Combination combination)
    {
        List<Combination> combinations = itemManager.GetCombinations();
        if (combinations.Contains(combination))
        {
            combinations.Remove(combination);
        }
    }
}