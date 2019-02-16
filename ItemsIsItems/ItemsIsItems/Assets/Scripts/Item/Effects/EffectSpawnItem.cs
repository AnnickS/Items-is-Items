using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


[CreateAssetMenu(menuName = "Effects/SpawnAtSecond")]
public class EffectSpawnItem : Effect {

    public GameObject itemToSpawn;

    public override void Execute(Item sender, Item interactor)
    {
        GameObject item = GameObject.Instantiate<GameObject>(itemToSpawn);
        item.transform.position = interactor.transform.position;
    }

    public override Effect LoadArgs(System.Object[] args)
    {
        itemToSpawn = ItemLoader.GetItemGameObject((String)args[0]);
        return this;
    }

    public override void ToSafeFormat(StringBuilder stringBuilder)
    {
        stringBuilder.Append("{SpawnUnderItem ");
        stringBuilder.Append(itemToSpawn.name);
        stringBuilder.Append("}");
    }
}
