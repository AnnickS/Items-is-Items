using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardMouse : MoveTowardPosition
{
    public int mouseButton = 1;
    
    private bool holding = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);
            if (hit && hit.transform.GetComponent<Item>() != null && hit.transform.GetComponent<Item>().inventory != false)
            {
                holding = true;
            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                base.moveToPosition(mousePosition);
            }
            
        }
        else if (Input.GetMouseButton(mouseButton))
        {
            if (holding == false)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                base.moveToPosition(mousePosition);
            }
        }
        else
        {
            holding = false;
        }
    }
}
