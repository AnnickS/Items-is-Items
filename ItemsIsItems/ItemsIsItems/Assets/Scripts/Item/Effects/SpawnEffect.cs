using System;
using UnityEngine;

public class EffectSpawn : IEffect
{
    public GameObject prefab;
    public Transform transform;

    public void Execute(Item sender, Item interactor)
    {
        GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public IEffect LoadArgs(String[] args)
    {
        prefab = ItemLoader.GetItemGameObject(args[0]);
        //transform = GameManager.instance.GetItemByID(args[1]);
        return this;
    }
}