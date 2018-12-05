using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    SpriteRenderer spriteImage;

    // Use this for initialization
    void Start () {
        spriteImage = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeColor(Color color)
    {
        spriteImage.color = color;
    }

    public void changeStat()
    {
    }
}
