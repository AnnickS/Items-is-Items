using System;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/SpawnAt")]
public class EffectSpawn : Effect
{
    public GameObject prefab;
    public GameObject targetItemPosition;

    public override void Execute(Item sender, Item interactor)
    {
        GameObject.Instantiate(prefab, targetItemPosition.transform.position, Quaternion.identity);
    }

    public override bool IsInitialized()
    {
        return prefab != null && targetItemPosition != null;
    }
}