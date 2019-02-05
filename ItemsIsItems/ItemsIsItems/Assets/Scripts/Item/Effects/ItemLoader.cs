using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ItemLoader
{
    public static GameObject GetItemGameObject(String itemName)
    {
        return Resources.Load<GameObject>(itemName);
    }
}
