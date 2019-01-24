using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawn : IEffect
{
    public GameObject prefab;
    public Transform transform;

    public void Execute(Item sender, Item interactor)
    {
        GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
    }
}