using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class Effect : ScriptableObject{

    protected virtual void OnEnable()
    {
        if (IsInitialized() == false)
        {
            Debug.LogWarning(name + ", Effect, is not initialized!");
        }
    }

    public abstract void Execute(Item sender, Item interactor);
    public abstract bool IsInitialized();
}
