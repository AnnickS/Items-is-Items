using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    public void ToSafeFormat(StringBuilder stringBuilder)
    {
        stringBuilder.Append("{SpawnUnderItem ");
        stringBuilder.Append(itemToSpawn.name);
        stringBuilder.Append("}");
    }
}
