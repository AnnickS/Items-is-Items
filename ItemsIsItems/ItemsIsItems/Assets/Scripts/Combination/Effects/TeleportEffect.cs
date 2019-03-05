using UnityEngine;

public class TeleportEffect : Effect
{
    public GameObject teleportPosition;

    public override void Execute(Item sender, Item interactor)
    {
        interactor.gameObject.transform.position = teleportPosition.transform.position;
    }

    public override bool IsInitialized()
    {
        return teleportPosition != null;
    }
}