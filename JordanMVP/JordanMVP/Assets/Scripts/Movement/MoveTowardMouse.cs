using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardMouse : MoveTowardPosition
{
    public int mouseButton = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton) || Input.GetMouseButton(mouseButton))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            base.goToPosition(mousePosition);
        }
    }
}
