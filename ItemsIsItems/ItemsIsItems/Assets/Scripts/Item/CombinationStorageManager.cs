using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public static class CombinationStorageManager
{
    private static Combination[] combinations;

    public static Combination[] Load()
    {
        combinations = Resources.LoadAll<Combination>("Combinations");
        return combinations;
    }

    public static Combination[] GetCombinations()
    {
        if(combinations == null)
        {
            Load();
        }
        return combinations;
    }
}