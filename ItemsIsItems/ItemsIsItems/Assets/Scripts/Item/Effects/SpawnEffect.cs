using System;
using System.Text;
using UnityEngine;

public class EffectSpawn : IEffect
{
    public GameObject prefab;
    public Item targetItemPosition;

    public void Execute(Item sender, Item interactor)
    {
        GameObject.Instantiate(prefab, targetItemPosition.transform.position, Quaternion.identity);
    }

    public IEffect LoadArgs(System.Object[] args)
    {
        prefab = ItemLoader.GetItemGameObject((System.String)args[0]);
        targetItemPosition = GameManager.instance.GetItemByNickname((System.String)args[1]);
        return this;
    }

    public void ToSafeFormat(StringBuilder stringBuilder)
    {
        stringBuilder.Append("{Spawn ");
        stringBuilder.Append(prefab.name);
        stringBuilder.Append(" ");
        stringBuilder.Append(targetItemPosition.nickname);
        stringBuilder.Append("}");
    }
}