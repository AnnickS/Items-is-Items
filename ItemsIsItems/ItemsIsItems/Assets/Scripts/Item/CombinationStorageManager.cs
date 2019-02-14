using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public static class CombinationStorageManager
{
    private const String COMBINATIONFILE = "Combinations.txt";
    private static List<Combination> combinations = new List<Combination>();
    public static bool isLoaded = false; 

    public static List<Combination> Load()
    {
        if (combinations.Count == 0)
        {
            string fileText = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, COMBINATIONFILE));

            IEffect effect = null;
            foreach (Match match in Regex.Matches(fileText, @"\s*(.*?)\s(.*?)\s({.*})"))
            {
                Debug.Log(match.Groups[1].Value + " + " + match.Groups[2].Value + " = " + match.Groups[3].Value);

                ItemValidator item1 = new ItemValidator(match.Groups[1].Value);
                String interactee = match.Groups[2].Value;
                effect = ParseEffect(match.Groups[3].Value);

                if (interactee.IndexOf('"') != -1)
                {
                    Descriptor d = Descriptor.GetDescriptor(interactee.Replace("\"", ""));
                    DescriptorValidator desc = new DescriptorValidator(d);
                    combinations.Add(new Combination(item1, desc, effect));
                }
                else
                {
                    ItemValidator item2 = new ItemValidator(interactee);
                    combinations.Add(new Combination(item1, item2, effect));
                }
            }
        }
        return combinations;
    }

    private static IEffect ParseEffect(String s)
    {
        Match m = Regex.Match(s, @"{(?:\s*({.*?}|.+?(?=[\s}])))*}");
        String[] args = new String[m.Groups[1].Captures.Count-1];
        for(int i = 0; i < args.Length; i++)
        {
            args[i] = m.Groups[1].Captures[i+1].Value;
        }

        return LoadEffect(m.Groups[1].Captures[0].Value, args);
    }

    private static IEffect LoadEffect(String effectName, String[] args)
    {
        switch (effectName)
        {
            case "Spawn":
                return new EffectSpawn().LoadArgs(args);
            case "Multi":
                List<IEffect> effects = new List<IEffect>();
                for(int i = 0; i < args.Length; i++)
                {
                    effects.Add(ParseEffect(args[i]));
                }
                return new EffectMultipleEffects().LoadArgs(effects.ToArray());
            case "SpawnUnderItem":
                return new EffectSpawnItem().LoadArgs(args);
            default:
                throw new Exception("Effect, "+effectName+", not found!");
        }
    }

    public static List<Combination> GetCombinations()
    {
        if(isLoaded == false)
        {
            isLoaded = true;
            Load();
        }
        return combinations;
    }

    public static void Save()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach(Combination combination in combinations){
            combination.ToSafeFormat(stringBuilder);
        }

        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, COMBINATIONFILE), stringBuilder.ToString());
    }  

    
    public static void AddCombination(Combination newCombination)
    {
        if (combinations.Contains(newCombination) == false)
        {
            combinations.Add(newCombination);
        }
    }

    public static void AddCombination(List<Combination> newCombinations)
    {
        foreach(Combination combination in newCombinations)
        {
            AddCombination(combination);
        }
    }
}