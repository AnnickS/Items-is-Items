using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class KeyPressed : MonoBehaviour
{
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {

        }
    }
}
