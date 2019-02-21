using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Respawn")]
public class EffectRespawn : Effect
{
    public override void Execute(Item sender, Item interactor)
    {
        if(interactor is Respawnable)
        {
            Respawnable respawnable = interactor as Respawnable;
            respawnable.Respawn();
        }
    }
}
