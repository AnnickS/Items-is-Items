using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseEnterExample : MonoBehaviour {

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

    private void OnMouseEnter()
    {
        Debug.Log("MouseEnter");

        //Note: Over will immediatly be called after this so it may be hard to catch the color
        sprite.color = enterColor;
    }

    private void OnMouseOver()
    {
        Debug.Log("MouseOver");
        sprite.color = overColor;
    }

    private void OnMouseExit()
    {
        Debug.Log("MouseExit");
        sprite.color = exitColor;
    }
}
