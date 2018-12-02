using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select
{
    private Selectable selectedItem;

    public void selectItem(Selectable newItem)
    {
        if (isItemSelected())
        {
            if(selectedItem == newItem)
            {
                deselect();
                return;
            }
            else
            {
                deselect();
            }
        }

        selectedItem = newItem;

        setColorOfItem(selectedItem, Color.gray);
    }

    private void setColorOfItem(Selectable item, Color color)
    {
        SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }

    public Selectable getSelectedItem()
    {
        return selectedItem;
    }

    public bool isItemSelected()
    {
        return selectedItem != null;
    }

    public void deselect()
    {
        setColorOfItem(selectedItem, Color.white);
        selectedItem = null;
    }

    private static Select instance;

    public static Select getInstance()
    {
        if (instance == null)
        {
            instance = new Select();
        }

        return instance;
    }

}
