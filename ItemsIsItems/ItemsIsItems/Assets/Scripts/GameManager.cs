using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Combination[] combinations;
    private List<CombinationListener> combinationListeners = new List<CombinationListener>();

    private void Awake()
    {
        Instance = this;
        Debug.Log(Descriptor.PrintDescriptorTree());
        combinations = GetCombinations();
    }

    public void ExecuteInteraction(Item item1, Item item2)
    {
        tellCombinationListeners(item1, item2);

        foreach (Combination combination in combinations)
        {
            if (combination.Match(item1, item2))
            {
                Effect effect = combination.GetEffect();
                effect.Execute(item1, item2);
                break;
            }
        }
    }

    public void AddCombinationListener(CombinationListener combinationListener)
    {
        combinationListeners.Add(combinationListener);
    }

    public void RemoveCombinationListener(CombinationListener combinationListener)
    {
        if(combinationListeners.Contains(combinationListener))
        {
            combinationListeners.Remove(combinationListener);
        }
    }

    private void tellCombinationListeners(Item item1, Item item2)
    {
        for(int index = combinationListeners.Count - 1; index >= 0; index--)
        {
            CombinationListener combinationListener = combinationListeners[index];

            if (combinationListener == null)
            {
                combinationListeners.Remove(combinationListener);
            }
            else
            {
                combinationListener.ItemsCombined(item1, item2);
            }
        }
    }

    public Item GetItemByNickname(String name)
    {
        foreach(Item item in GameObject.FindObjectsOfType<Item>())
        {
            if(item.nickname == name)
            {
                return item;
            }
        }
        throw new Exception("Item nickname not found!");
    }

    public Combination[] Load()
    {
        combinations = Resources.LoadAll<Combination>("Combinations");
        return combinations;
    }

    public Combination[] GetCombinations()
    {
        if (combinations == null)
        {
            Load();
        }
        return combinations;
    }

}
