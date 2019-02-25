using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ChangeColorOfSecond")]
public class EffectChangeColor : Effect {
    [SerializeField]
    Color color;

    public override void Execute(Item sender, Item interactor)
    {
        interactor.GetComponent<SpriteRenderer>().color = color;

        Destroy(sender.gameObject);
    }

    public override bool IsInitialized()
    {
        return color != null;
    }
}
