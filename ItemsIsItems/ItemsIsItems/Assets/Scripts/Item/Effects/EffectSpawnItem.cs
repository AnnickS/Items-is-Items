using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnItem : IEffect {

    public GameObject itemToSpawn;

    public void Execute(Item sender, Item interactor)
    {
        GameObject item = GameObject.Instantiate<GameObject>(itemToSpawn);
        item.transform.position = interactor.transform.position;
    }

    public IEffect LoadArgs(System.Object[] args)
    {
        itemToSpawn = ItemLoader.GetItemGameObject((String)args[0]);
        return this;
    }
}
