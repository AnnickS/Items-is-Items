using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    private static Inventory instance;

    public static Inventory getInstance()
    {
        if(instance == null)
        {
            instance = new Inventory();
        }

        return instance;
    }

}
