using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EffectAction(GameObject item1, GameObject item2);


//Kill (GameObject, GameObject.home)
//Change Color (GameObject, Color) - For every attribute
//Spawn (GameObject, Position)
//Teleport (GameObject, Position)
//Quest (...)

public static class Effect {

    public static EffectAction CreateEffect(GameObject item1, GameObject item2)
    {
        


        Delegate s = new EffectAction((one, two) => one.GetComponent<SpriteRenderer>().material.color = Color.yellow);

        s.DynamicInvoke(item1, item2);
    }
}
