using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class Validator : ScriptableObject
{
    protected virtual void OnEnable()
    {
        if (IsInitialized() == false)
        {
            Debug.LogWarning(name + ", Validator, is not initialized!");
        }
    }

    public abstract String GetName();
    public abstract bool ValidateItem(Item item);
    public abstract bool IsInitialized();
}
