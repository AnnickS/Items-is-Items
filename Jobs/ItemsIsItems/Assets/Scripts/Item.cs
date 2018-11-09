using System;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameObject graphicalObj;

    void Start()
    {
        graphicalObj = transform.Find("Mesh").gameObject;
        if(graphicalObj == null)
        {
            graphicalObj = gameObject;
        }
    }

    public void ChangeColor(Color newColor)
    {
        graphicalObj.GetComponent<MeshRenderer>().material.color = newColor;
    }
}
