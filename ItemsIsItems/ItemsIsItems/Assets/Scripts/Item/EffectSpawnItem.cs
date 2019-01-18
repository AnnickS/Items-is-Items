using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnItem : Effect {

    public Item itemToSpawn;

    public void actOn(GameObject item1, GameObject item2)
    {
        Item item = GameObject.Instantiate<Item>(itemToSpawn);
        item.transform.position = item2.transform.position;
    }
}
