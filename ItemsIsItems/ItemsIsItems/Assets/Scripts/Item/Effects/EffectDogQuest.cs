using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/EffectDogQuest")]
public class EffectDogQuest : Effect
{

    public override void Execute(Item sender, Item interactor)
    {
        Destroy(sender.gameObject);
    }
}
