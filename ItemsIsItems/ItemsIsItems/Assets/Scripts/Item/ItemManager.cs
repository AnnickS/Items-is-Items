using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager {//: MonoBehaviour {
    
    public static ItemManager Instance;
    private List<Combination> combinations = new List<Combination>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Initialize()
    {
        Instance = new ItemManager();
        Debug.Log(Descriptor.GetDescriptor("ROOT").ToStringRecursive());
        CombinationStorageManager.Load();
        //Instance.combinations.Add(new GeneralItemCombination(new Item(), Descriptor.ROOT.GetDescriptor("Food"), new EffectSpawn()));
    }

    /*
	// Use this for initialization
	void Start () {
        Instance = this;
	}*/

    /*
	// Update is called once per frame
	void Update () {
		
	}*/

    public void ExecuteInteraction(Item item1, Item item2)
    {
        foreach (Combination combination in combinations)
        {
            if(combination.Match(item1, item2))
            {
                IEffect effect = combination.GetEffect();
                effect.Execute(item1, item2);
                break;
            }
        }
    }
}
