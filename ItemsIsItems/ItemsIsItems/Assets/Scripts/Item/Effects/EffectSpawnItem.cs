using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnItem : IEffect {

    public Item itemToSpawn;

    public void Execute(Item sender, Item interactor)
    {
        Item item = GameObject.Instantiate<Item>(itemToSpawn);
        item.transform.position = interactor.transform.position;
    }
}
