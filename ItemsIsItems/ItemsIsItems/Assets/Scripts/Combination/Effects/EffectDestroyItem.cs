using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/DestroyItem")]
public class EffectDestroyItem : Effect
{
    public override void Execute(Item sender, Item interactor)
    {
        interactor.gameObject.SetActive(false);
    }

    public override bool IsInitialized()
    {
        return true;
    }
}
