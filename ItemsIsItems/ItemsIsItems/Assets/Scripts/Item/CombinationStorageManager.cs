using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class CombinationStorageManager
{
    private static List<Combination> combinations = new List<Combination>();

    public static List<Combination> Load()
    {
        string[] lines = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "Combinations.txt"));
        foreach (string line in lines)
        {
            String[] strings = line.Split();
            String[] effectArgs = new String[strings.Length-3];
            Array.Copy(strings, effectArgs, effectArgs.Length)
            String item1 = strings[0];
            IEffect effect = new EffectSpawn(effectArgs);
            if (strings[1].IndexOf('"') != -1)
            {
                Descriptor desc = Descriptor.GetRoot().GetDescriptor(strings[1]);
                combinations.Add(new GeneralItemCombination(item1, desc, effect));
            }
            else
            {

            }
        }


        throw new NotImplementedException();
    }

    public static List<Combination> GetCombinations()
    {
        throw new NotImplementedException();
    }

    public static void Save()
    {
        throw new NotImplementedException();
    }
    /*
    public static void AddCombination(Combination newCombination)
    {
        throw new NotImplementedException(); //combinations.Add(newCombination);
    }

    public static void AddCombination(List<Combination> newCombinations)
    {
        throw new NotImplementedException(); //combinations.AddRange(newCombinations);
    }*/
}