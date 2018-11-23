using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;
    
	void Awake () {
        gameManager = this; 
	}

    public void OnItemTouch(Item item1, Item item2)
    {

    }

}
