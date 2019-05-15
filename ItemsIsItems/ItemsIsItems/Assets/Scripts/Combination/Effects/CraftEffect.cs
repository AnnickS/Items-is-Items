using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/CraftItem")]
public class CraftEffect : Effect
{
    public bool deleteItem1 = true;
    public bool deleteItem2 = true;

    public List<GameObject> itemsToSpawn = new List<GameObject>();

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
        if(itemsToSpawn != null && itemsToSpawn.Count > 0)
        {
            return true;
        }
        return false;
    }
}
