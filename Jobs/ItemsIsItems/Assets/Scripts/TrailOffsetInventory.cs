using System;
using System.Collections.Generic;
using UnityEngine;

public class TrailOffsetInventory : Inventory
{

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if(player == null)
        {
            return;
        }

        for(int i = 0; i < items.Count; i++){
            Item item = items[i];
            Vector3 pos = transform.position;
            if (i != 0)
            {
                pos = items[i - 1].transform.position;
            }
            item.GetComponent<Movement>().SetTargetPosition(pos);
        }
    }

    public override void Open()
    {
        return;
    }

    public override void Close()
    {
        return;
    }


    public override void AddItem(Item item)
    {
        base.AddItem(item);
        item.GetComponent<Movement>().SetMoveable(true);
    }

    public override void removeItem(Item item)
    {
        base.removeItem(item);
        item.GetComponent<Movement>().SetMoveable(false);
    }

    
}
