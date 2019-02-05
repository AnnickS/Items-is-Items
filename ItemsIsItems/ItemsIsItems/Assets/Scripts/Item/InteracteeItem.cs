using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InteracteeItem : IInteractable
{
    public String item;

    public InteracteeItem(String item)
    {
        this.item = item;
    }

    public string GetName()
    {
        return item;
    }

    public bool ItemMatch(Item interactee)
    {
        if(item == null)
        {
            throw new MissingFieldException("InteracteeItem item is NULL");
        }
        else
        {
            return interactee.name == item;
        }
    }

    public void ToSafeFormat(StringBuilder stringBuilder)
    {
        stringBuilder.Append(GetName());
    }
}
