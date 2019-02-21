using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;

public delegate void CombinationEventHandler();

[CreateAssetMenu(menuName = "Combination/Combination")]
public class Combination : ScriptableObject
{
    public Validator itemValidator1;
    public Validator itemValidator2;
    [SerializeField]
    private Effect effect;

    private event CombinationEventHandler CombinationEvent;

    private void OnAwake()
    {
        if (itemValidator1 == null)
        {
            Debug.LogError("Combination, " + name + ", is missing itemValidator1!");
        }
        if(itemValidator2 == null)
        {
            Debug.LogError("Combination, " + name + ", is missing itemValidator2!");
        }
        if(effect == null)
        {
            Debug.LogError("Combination, " + name + ", is missing an effect!");
        }
    }

    public bool IsMatch(Item item1, Item item2)
    {
        return (itemValidator1.ValidateItem(item1) && itemValidator2.ValidateItem(item2));
    }
    
    public void Execute(Item item1, Item item2)
    {
        effect.Execute(item1, item2);
        //Debug.Log("Executed "+name);
        if (CombinationEvent != null)
        {
            //Debug.Log("Invoke");
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

    public override string ToString()
    {
        return itemValidator1.GetName() + " + " + itemValidator2.GetName();
    }
}