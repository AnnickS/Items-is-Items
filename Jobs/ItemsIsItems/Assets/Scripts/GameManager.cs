using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;
    public List<ItemInteraction> interactions = new List<ItemInteraction>();
    
	void Awake () {
        gameManager = this;
        LoadInteractions();
	}

    public void LoadInteractions()
    {
        interactions.Add(new ItemInteraction("Player", "Test", (item1, item2) => item1.graphicalObj.GetComponent<MeshRenderer>().material.color = Color.blue));
    }

    public void OnItemTouch(ItemInteractionRequest itemInteraction)
    {
        ItemInteraction interaction = GetInteraction(itemInteraction);
        if(interaction != null)
        {
            interaction.GetInteraction().Invoke(itemInteraction.item2, itemInteraction.item1);
        }
    }

    public ItemInteraction GetInteraction(ItemInteractionRequest request)
    {
        foreach(ItemInteraction interaction in interactions)
        {
            if (interaction.IsMatch(request))
            {
                return interaction;
            }
        }
        return null;
    }

}

public class ItemInteractionRequest
{
    public Item item1;
    public Item item2;
    public bool flipped;

    public ItemInteractionRequest(Item item1, Item item2)
    {
        if (item1.name.CompareTo(item2.name) >= 0) { 
            this.item1 = item1;
            this.item2 = item2;
        }
        else
        {
            this.item1 = item2;
            this.item2 = item1;
        }
    }
}

public class ItemInteraction
{
    string item1;
    string item2;
    Action<Item, Item> interaction;

    public ItemInteraction(string item1, string item2, Action<Item, Item> interation)
    {
        if (item1.CompareTo(item2) >= 0)
        {
            this.item1 = item1;
            this.item2 = item2;
        }
        else
        {
            this.item1 = item2;
            this.item2 = item1;
        }
        this.interaction = interation;
    }

    public bool IsMatch(ItemInteractionRequest request)
    {
        return (item1 == request.item1.name && item2 == request.item2.name) ;
    }

    public Action<Item, Item> GetInteraction()
    {
        return interaction;
    }
}
