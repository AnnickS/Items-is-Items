using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class OnCollideEnterExample : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter");

        //Note: Stay will immediatly be called after this so it may be hard to catch the color
        sprite.color = enterColor;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("CollisionStay");
        sprite.color = stayColor;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("CollisionExit");
        sprite.color = exitColor;
    }

}
