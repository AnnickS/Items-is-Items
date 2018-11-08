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

            Select selected = Select.getInstance();

            if(selected.isItemSelected())
            {
                Selectable selectedItem = selected.getSelectedItem();
                mousePosition.z = selectedItem.transform.position.z;
                selectedItem.transform.position = mousePosition;
            }

            if(ItemSlot.isItemSelected())
            {
                Selectable selectedItem = ItemSlot.getSelectedItem();
                ItemSlot.deselect();
                mousePosition.z = selectedItem.transform.position.z;
                selectedItem.transform.position = mousePosition;

            }
        }
    }
}
