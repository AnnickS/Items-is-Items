using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed;
    private Rigidbody2D playerBody;
    Vector2 playerMovement = new Vector2();

    private void FixedUpdate()
    {
        playerMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerBody.AddForce(playerMovement*speed);
    }

    // Use this for initialization
    void Start () {
        playerBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
