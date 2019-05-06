using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/CraftItem")]
public class CraftEffect : Effect
{
    public GameObject itemToSpawn;

    public override void Execute(Item sender, Item interactor)
    {
        Instantiate(itemToSpawn, interactor.transform.position, Quaternion.identity);
        sender.Destroy();
        interactor.Destroy();
    }

    public override bool IsInitialized()
    {
        if(itemToSpawn != null)
        {
            return true;
        }
        return false;
    }
}
