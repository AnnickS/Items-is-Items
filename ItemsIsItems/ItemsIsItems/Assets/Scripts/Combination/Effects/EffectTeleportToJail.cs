﻿using UnityEngine;

[CreateAssetMenu(menuName = "Effects/EffectTeleportToJail")]
public class EffectTeleportToJail : Effect
{
    public override void Execute(Item sender, Item interactor)
    {
        Debug.Log("In here...");
        GameObject jail = sender.GetJail();
        if (jail != null)
        {
            Debug.Log("In here.");
            Inventory inven = interactor.GetComponent<Inventory>();
            if(inven != null)
            {
                inven.RemoveAll();
            }

            Debug.Log("In here!");
            interactor.gameObject.transform.position = jail.transform.position;
        }
        else
        {
            Debug.LogWarning(sender.name + " does not have a jail to send " + interactor.name + " to!");
        }
    }

    public override bool IsInitialized()
    {
        return true;
    }
}