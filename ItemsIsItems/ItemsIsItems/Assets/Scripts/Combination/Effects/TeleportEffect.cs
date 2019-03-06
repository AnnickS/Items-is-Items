using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Teleport")]
public class TeleportEffect : Effect
{
    public override void Execute(Item sender, Item interactor)
    {
        GameObject jail = sender.GetJail();
        if (jail != null)
        {
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