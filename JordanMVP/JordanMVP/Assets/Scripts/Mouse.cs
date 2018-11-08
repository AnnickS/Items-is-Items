using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    public int mouseButton = 0;

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton) || Input.GetMouseButton(mouseButton))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Selected selected = Selected.getInstance();

            if(selected.isItemSelected())
            {
                Pickup selectedItem = selected.getSelectedItem();
                mousePosition.z = selectedItem.transform.position.z;
                selectedItem.transform.position = mousePosition;
            }
        }
    }
}
