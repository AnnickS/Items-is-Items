﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;

public delegate void CombinationEventHandler();

[CreateAssetMenu(menuName = "Combination")]
public class Combination : ScriptableObject
{
    public Validator itemValidator1;
    public Validator itemValidator2;
    [SerializeField]
    private Effect effect;

    private event CombinationEventHandler CombinationEvent;

    private void OnEnable()
    {
        if (IsInitialized() == false)
        {
            Debug.LogWarning(name + ", Combination, is not initialized!");
        }
    }

    public bool IsMatch(Item item1, Item item2)
    {
        return (itemValidator1.ValidateItem(item1) && itemValidator2.ValidateItem(item2) 
            || itemValidator1.ValidateItem(item2) && itemValidator2.ValidateItem(item1));
    }
    
    public void Execute(Item item1, Item item2)
    {
        if (itemValidator1.ValidateItem(item1) && itemValidator2.ValidateItem(item2)){
            effect.Execute(item1, item2);
        }
        else if (itemValidator1.ValidateItem(item2) && itemValidator2.ValidateItem(item1))
        {
            effect.Execute(item2, item1);
        }
        if (CombinationEvent != null)
        {
            CombinationEvent.Invoke();            
        }
    }

    public void Subscribe(CombinationEventHandler handler)
    {
        //Debug.Log("Subscribed to "+ name);
        if (handler != null)
        {
            CombinationEvent += handler;
        }
    }

    public void Unsubscribe(CombinationEventHandler handler)
    {
        if (handler != null)
        {
            CombinationEvent -= handler;
        }
    }

    public bool IsInitialized()
    {
        try
        {
            return itemValidator1.IsInitialized() && itemValidator2.IsInitialized() && effect.IsInitialized();
        }
        catch (Exception)
        {
            return false;
        }
    }

    public override string ToString()
    {
        return itemValidator1.GetName() + " + " + itemValidator2.GetName();
    }
}