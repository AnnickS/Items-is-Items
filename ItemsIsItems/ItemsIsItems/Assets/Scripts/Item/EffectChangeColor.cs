using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectChangeColor : Effect
{
    public override void actOn(GameObject item1, GameObject affectedItem)
    {
        Debug.Log("Color changed");
        affectedItem.GetComponent<SpriteRenderer>().material.color = Color.yellow;
    }
}
