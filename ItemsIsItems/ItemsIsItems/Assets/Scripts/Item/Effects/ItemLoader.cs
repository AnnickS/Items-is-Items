using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ItemLoader
{
    public static void LoadItems()
    {
        string[] lines = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "Items.txt"));
        foreach (string line in lines)
        {
            
        }


        throw new NotImplementedException();
    }

    public static GameObject GetItemGameObject(String itemName)
    {
        return Resources.Load<GameObject>(itemName);
    }
}
