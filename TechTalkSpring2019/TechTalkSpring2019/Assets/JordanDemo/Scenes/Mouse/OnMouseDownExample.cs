using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownExample : MonoBehaviour {

    public Color startColor = Color.white;
    public Color enterColor = Color.green;
    public Color overColor = Color.cyan;
    public Color exitColor = Color.blue;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.color = startColor;
    }

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");

        //Note: Drag will immediatly be called after this so it may be hard to catch the color
        sprite.color = enterColor;
    }

    private void OnMouseDrag()
    {
        Debug.Log("MouseDrag");
        sprite.color = overColor;
    }

    //Note as opposed to OnMouseUp, 
    //this is only called if the mouse button is released when over this object
    private void OnMouseUpAsButton()
    {
        Debug.Log("MouseUpAsButton");
        sprite.color = exitColor;
    }
}
