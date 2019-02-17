using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    
    public static ItemManager Instance;
    private Combination[] combinations;

    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void Awake()
    {
        Instance = this;
        Debug.Log(Descriptor.PrintDescriptorTree());
        combinations = CombinationStorageManager.GetCombinations();
    }

    public void ExecuteInteraction(Item item1, Item item2)
    {
        foreach (Combination combination in combinations)
        {
            if(combination.Match(item1, item2))
            {
                Effect effect = combination.GetEffect();
                effect.Execute(item1, item2);
                break;
            }
        }
    }
}
