using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/CraftItem")]
public class CraftEffect : Effect
{
    public bool deleteItem1 = true;
    public bool deleteItem2 = true;

    public GameObject[] itemsToSpawn;

    public override void Execute(Item sender, Item interactor)
    {
        foreach (GameObject objToSpawn in itemsToSpawn)
        {
            Instantiate(objToSpawn, interactor.transform.position, Quaternion.identity);
        }
        if (deleteItem1) sender.Destroy();
        if (deleteItem2) interactor.Destroy();
    }

    public override bool IsInitialized()
    {
        if(itemsToSpawn != null && itemsToSpawn.Length > 0)
        {
            return true;
        }
        return false;
    }
}
