using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject followBehind;
    private Rigidbody2D Body;
    [SerializeField]
    private float Speed = 4;
    private Vector2 Direction;
    private Vector2 PlayerPosition;
    private bool onDrag = false;
    private bool inPlayerInventory = false;
    public bool overPlayer = false;

    // Use this for initialization
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();

        player = GameObject.Find("AlienGirl");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inPlayerInventory)
        {
            changeMovement();
        }
    }

    void OnMouseDrag()
    {
        if (inPlayerInventory)
        {
            inPlayerInventory = false;

            PlayerInventory inventory = player.GetComponent<PlayerInventory>();
            string stalkedBy = inventory.getPreviousItem(this.gameObject);

            if(stalkedBy != null)
            {
                GameObject stalker = GameObject.Find(stalkedBy);

                stalker.GetComponent<FollowMovement>().setFollowBehind(this.followBehind);
            }

            inventory.removeInventoryItem(this.gameObject);
            followBehind = null;
            onDrag = true;
        }
        if (onDrag)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objectPosition;
        }
    }

    void OnMouseUp()
    {
        //Prevent the player from grabbing it if in-world
        if (onDrag)
        {
            onDrag = false;
            if (overPlayer)
            {
                player.GetComponent<Player>().changeColor(Color.green);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            overPlayer = false;
        }
    }

    private void changeMovement()
    {
        PlayerPosition = new Vector2(followBehind.transform.position.x, followBehind.transform.position.y);
        Vector2 Distance = new Vector2(transform.position.x, transform.position.y) - PlayerPosition;

        if(Distance.magnitude > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition, Speed * Time.deltaTime);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (onDrag)
        {
            overPlayer = true;

        }
        //Check the provided Collider2D parameter other to see if it is tagged "Player", if it is...
        if (other.gameObject.CompareTag("Player") && (inPlayerInventory == false))
        {
            inPlayerInventory = true;
            followBehind = player;

            //Changes the followObject of the last inventory item to this item
            if (player.GetComponent<PlayerInventory>().getInventoryCount() > 0)
            {
                GameObject firstItem = GameObject.Find(player.GetComponent<PlayerInventory>().getLastAdded());
                firstItem.GetComponent<FollowMovement>().setFollowBehind(this.gameObject);
            }

            //Adds item to inventory list
            player.GetComponent<PlayerInventory>().addInventoryItem(this.gameObject);
        }
    }

    public void setFollowBehind(GameObject newFollow)
    {
        followBehind = newFollow;
    }
}
