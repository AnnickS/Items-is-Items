using System;
using System.Text;
using UnityEngine;

public class EffectSpawn : IEffect
{
    public GameObject prefab;
    public Transform transform;

    public void Execute(Item sender, Item interactor)
    {
        GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public IEffect LoadArgs(System.Object[] args)
    {
        prefab = ItemLoader.GetItemGameObject((System.String)args[0]);
        //transform = GameManager.instance.GetItemByID(args[1]);
        return this;
    }

    public void ToSafeFormat(StringBuilder stringBuilder)
    {
        throw new NotImplementedException();
    }
}