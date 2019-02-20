using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Validator/Item")]
public class ItemValidator : Validator
{
    public String item;

    public override string GetName()
    {
        return item;
    }

    public override bool ValidateItem(Item item)
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
