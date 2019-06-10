using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class OnTriggerEnterExample : MonoBehaviour
{
    public Color startColor = Color.white;
    public Color enterColor = Color.green;
    public Color stayColor = Color.cyan;
    public Color exitColor = Color.blue;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.color = startColor;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log("TriggerEnter");

        //Note: Stay will immediatly be called after this so it may be hard to catch the color
        sprite.color = enterColor;
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        Debug.Log("TriggerStay");
        sprite.color = stayColor;
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        Debug.Log("TriggerExit");
        sprite.color = exitColor;
    }

}
