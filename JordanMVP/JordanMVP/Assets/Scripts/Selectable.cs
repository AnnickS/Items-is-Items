using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Selectable : MonoBehaviour
{
    //inventory put into UI

    void OnMouseDown()
    {
        Select.getInstance().selectItem(this);
    }
}
