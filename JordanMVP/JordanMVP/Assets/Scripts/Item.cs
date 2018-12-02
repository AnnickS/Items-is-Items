using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Item : Selectable{

    public abstract void usedOn(Item itemUsed);
}
