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

    private void Awake()
    {
        Instance = this;
        Descriptor.PrintDescriptorTree();
        combinations = GetCombinations();
        Debug.Log(combinations.Length);
    }

    public void ExecuteInteraction(Item item1, Item item2)
    {
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
