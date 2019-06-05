using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveTowardMouse : MoveTowardPosition
{
    public int mouseButton = 1;
    
    private bool holding = false;
    private bool interacting = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            if (PauseGame.isGamePaused)
            {
                return;
            }

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f);
            if (hit == true && hit.transform.GetComponent<Item>() != null && hit.transform.GetComponent<Item>().inventoryWithin != false)
            {
                holding = true;
            }
            else if (hit == true && hit.transform.GetComponent<NPC>() != null)
            {
                interacting = true;
            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                base.moveToPosition(mousePosition);
            }
            
        }
        else if (Input.GetMouseButton(mouseButton))
        {
            if (holding == false && interacting == false)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                base.moveToPosition(mousePosition);
            }
        }
        else
        {
            holding = false;
            interacting = false;
        }
    }
}
