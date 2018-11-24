using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //public bool canMove = true;

    LinkedList<int> touches = new LinkedList<int>();

    Movement move;
    Inventory inventory;

    void Start () {
        inventory = GetComponent<Inventory>();
        move = GetComponent<Movement>();
        InputManager.instance.OnTouchDown.AddListener(OnFingerDown);
    }

    private void Update()
    {
        if (touches.Count > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(InputManager.instance.GetTouch(touches.First.Value).Value.position);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 10000f, 1 << LayerMask.NameToLayer("Ground"));
            move.SetTargetPosition(hit.point);
        }
        else
        {
            move.CancelMove();//.isMoving = false;
        }
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
                case "Ground":
                    touches.AddFirst(touch.fingerId);
                    InputManager.instance.OnTouchEnd(touch.fingerId, OnFingerUp);
                    break;
                case "Item":
                Item item = hit.transform.GetComponent<Item>();
                    if (inventory.Contains(item) == false){
                        touches.AddFirst(touch.fingerId);
                        InputManager.instance.OnTouchEnd(touch.fingerId, OnFingerUp);
                    }
                break;
            }
        }
    }

    private void OnFingerUp(Touch touch)
    {
        touches.Remove(touch.fingerId);
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
