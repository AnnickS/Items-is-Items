using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GoForward : MonoBehaviour {

    public Vector2 movement;
    private Rigidbody2D rigidBody;
    // Use this for initialization
    void Start () {
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(movement);
    }
}
