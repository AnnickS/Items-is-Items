using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public Vector3 FrontFacing;
    public float RotationSpeed = 10F;

    private void Start()
    {
    }

    //Moves the object in a circle
    public void RotateInPlace()
    {
        transform.Rotate(new Vector3(0, 0, 1.5F));
    }

    void RotateToFront()
    {
    }
}
