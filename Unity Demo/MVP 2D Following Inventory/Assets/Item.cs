using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    private bool activate = false;
    FollowMovement itemMovementData;

	// Use this for initialization
	void Start () {
        itemMovementData = this.GetComponent<FollowMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
    }
}
