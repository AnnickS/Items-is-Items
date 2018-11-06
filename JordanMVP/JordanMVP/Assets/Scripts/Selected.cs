﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected
{
    private Pickup selectedItem;

    public void Select(Pickup newItem)
    {


        if(isItemSelected())
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

    private void setColorOfItem(Pickup item, Color color)
    {
        SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }

    internal Pickup getSelectedItem()
    {
        return selectedItem;
    }

    internal bool isItemSelected()
    {
        return selectedItem != null;
    }

    internal void deselect()
    {
        setColorOfItem(selectedItem, Color.white);
        selectedItem = null;
    }

    private static Selected instance;

    public static Selected getInstance()
    {
        if (instance == null)
        {
            instance = new Selected();
        }

        return instance;
    }

}
