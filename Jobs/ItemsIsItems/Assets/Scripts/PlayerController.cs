using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //public bool canMove = true;


    Movement move;
    Inventory inventory;

    void Start () {
        inventory = GetComponent<Inventory>();
        move = GetComponent<Movement>();
        InputManager.instance.OnTouch.AddListener(OnFingerDown);
    }

    private void OnFingerDown(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
            switch (LayerMask.LayerToName(hit.collider.gameObject.layer))
            {
                case "Player":
                    if(hit.transform == this.transform){
                        move.SetTargetPosition(touch);
                    }
                    break;
                case "Ground":
                    move.SetTargetPosition(touch);
                    break;
                case "Item":
                    Item item = hit.transform.GetComponent<Item>();
                    if (inventory.Contains(item)){
                        inventory.RemoveItem(item);
                        hit.transform.GetComponent<Movement>().SetTargetPosition(touch);
                    }
                    break;
            }
        }
    }

    private void OnFingerUp(Touch touch)
    {

    }

    Vector3 GetMouseWorldPositionByCamera() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector3 GetMouseWorldPosistionByRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, 1 << LayerMask.NameToLayer("Ground")))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null && item.isPickupable)
        { 
            if (!inventory.Contains(item))
            {
                inventory.AddItem(item);
            }
        }
    }
}
