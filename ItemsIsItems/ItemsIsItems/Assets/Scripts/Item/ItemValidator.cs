using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Validator/Item")]
public class ItemValidator : Validator
{
    public String item;
    public ItemValidator(String item)
    {
        this.item = item;
    }

    public override string GetName()
    {
        return item;
    }

    public override bool ItemMatch(Item interactee)
    {
        if(item == null)
        {
            throw new MissingFieldException("ItemValidator item is NULL");
        }
        else
        {
            return interactee.name == item;
        }
    }
}
