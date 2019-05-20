using System;
using System.Collections.Generic;
using UnityEngine;

public class TrailOffsetInventory : Inventory
{
    public float speed = 10;
    public float distance = 0.5f;
    public float segmentSize = 0.1f;
    private List<Vector3> points = new List<Vector3>();

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if(belongsTo == null)
        {
            return;
        }

        if (points.Count == 0 || Vector3.Distance(points[0], transform.position) >= segmentSize)
        {
            if (points.Count > items.Count * (distance / segmentSize) +1)
            {
                points.RemoveAt(points.Count-1);
            }
            points.Insert(0, transform.position);            
        }

        for(int i = 0; i < items.Count; i++){
            if(points.Count <= (i+1) * Mathf.RoundToInt(distance / segmentSize))
            {
                break;
            }
            Item item = items[i];
            item.GetComponent<MoveTowardPosition>().speed = speed;
            item.GetComponent<MoveTowardPosition>().moveToPosition(points[(i+1)* Mathf.RoundToInt(distance / segmentSize)]);
        }

        /*
        foreach(KeyValuePair<int, Item> pair in selectedItems)
        {
            MoveSelectedItem(pair.Key, pair.Value);
        }*/
    }

    public override void RemoveAll()
    {
        base.RemoveAll();
        points.Clear();
    }

    public override void Open()
    {
        return;
    }

    public override void Close()
    {
        return;
    }

    public virtual void AddItemAtFront(Item item)
    {
        AddItemAt(item, 0);
    }

    public override void AddItemAt(Item item, int index)
    {
        base.AddItemAt(item, index);
        item.inventoryWithin = this;
        item.isPickupable = false;
    }

    public virtual void AddItemAtBack(Item item)
    {
        AddItemAt(item, items.Count);
    }

    public override void RemoveItem(Item item)
    {
        base.RemoveItem(item);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        //Check if other is an item and item not already in inventory
        if (item != null && !base.Contains(item) && item.isPickupable)
        {
            //Item is added to inventory
            this.AddItemAtFront(item);
        }
    }


    /*
    private void OnFingerDown(Touch touch)
    {
        
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            switch (LayerMask.LayerToName(hit.collider.gameObject.layer))
            {
                case "Item":
                    Item item = hit.transform.GetComponent<Item>();
                    if (Contains(item))
                    {
                        RemoveItem(item);
                        selectedItems.Add(touch.fingerId, item);
                        InputManager.instance.OnTouchEnd(touch.fingerId, OnFingerUp);                        ;
                        //hit.transform.GetComponent<Movement>().SetTargetPosition(touch);
                        //item.GetComponent<Movement>().CancelMove();
                    }
                    break;
            }
        }
        
    }
    */

    /*
    private void OnFingerUp(Touch touch)
    {
        //selectedItems.Remove(touch.fingerId);
    }
    */

    /*
    private void MoveSelectedItem(int touchID, Item item)
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.instance.GetTouch(touchID).Value.position);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 10000f, 1 << LayerMask.NameToLayer("Ground"));
        item.GetComponent<Movement>().SetTargetPosition(hit.point);
    }*/


}
