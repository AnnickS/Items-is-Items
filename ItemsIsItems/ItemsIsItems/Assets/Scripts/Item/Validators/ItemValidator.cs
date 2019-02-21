using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Validator/Item")]
public class ItemValidator : Validator
{
    public override string GetName()
    {
        return name;
    }

    public override bool ValidateItem(Item item)
    {
        if(item == null)
        {
            throw new MissingFieldException("ItemValidator item is NULL");
        }
        else
        {
            return item.name == name;
        }
    }

    public override bool IsInitialized()
    {
        return true;
    }
}
