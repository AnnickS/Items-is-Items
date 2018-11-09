using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Movement move;
    Inventory inventory;

    // Use this for initialization
    void Start () {
        move = GetComponent<Movement>();
        move.SetMoveable(true);
        inventory = GetComponent<Inventory>();
        inventory.player = this;
    }
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)){
            OnMouseHold();
        }
    }

    private void OnMouseHold()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            switch (LayerMask.LayerToName(hit.collider.gameObject.layer))
            {
                case "Ground":
                    move.SetTargetPosition(hit.point);
                    break;
                case "Item":
                    if (Input.GetMouseButtonDown(0))
                    {
                        Item item = hit.collider.gameObject.GetComponent<Item>();
                        if (!inventory.Contains(item))
                        {
                            inventory.AddItem(item);
                        }
                        else
                        {
                            inventory.removeItem(item);
                        }
                    }
                    break;
            }
        }
    }

    Vector3 GetMouseWorldPosistionByCamera() {
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

    Collider GetClickRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit.collider;
    }
}
