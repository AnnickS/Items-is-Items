using System;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/SpawnAt")]
public class EffectSpawn : Effect
{
    public GameObject prefab;
    public Item targetItemPosition;

    public override void Execute(Item sender, Item interactor)
    {
        GameObject.Instantiate(prefab, targetItemPosition.transform.position, Quaternion.identity);
    }
}