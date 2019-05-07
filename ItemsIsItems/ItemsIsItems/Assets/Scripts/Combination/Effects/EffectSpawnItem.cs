using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


[CreateAssetMenu(menuName = "Effects/SpawnAtInteractor")]
public class EffectSpawnItem : Effect {

    public GameObject itemToSpawn;

    public override void Execute(Item sender, Item interactor)
    {
        GameManager.Instance.SpawnItem(itemToSpawn, interactor.transform.position, Quaternion.identity);
    }

    public override bool IsInitialized()
    {
        return itemToSpawn != null;
    }
}
