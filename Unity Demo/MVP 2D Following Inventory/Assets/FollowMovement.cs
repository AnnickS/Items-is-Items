using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour {
    [SerializeField]
    private GameObject Player;
    private Rigidbody2D Body;
    [SerializeField]
    private float Speed = 4;
    private Vector2 Direction;
    private Vector2 PlayerPosition;
    public bool inPlayerInventory = false;

    // Use this for initialization
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();

        Player = GameObject.Find("AlienGirl");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inPlayerInventory)
        {
            changeMovement();
        }
    }

    private void changeMovement()
    {
        PlayerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 Distance = new Vector2(transform.position.x, transform.position.y) - PlayerPosition;

        if(Distance.magnitude > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition, Speed * Time.deltaTime);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Player", if it is...
        if (other.gameObject.CompareTag("Player"))
        {
            inPlayerInventory = true;
        }
    }
}
