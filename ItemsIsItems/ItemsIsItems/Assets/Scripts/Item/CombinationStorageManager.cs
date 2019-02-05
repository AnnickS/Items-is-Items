using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public static class CombinationStorageManager
{
    private static List<Combination> combinations = new List<Combination>();

    public static List<Combination> Load()
    {
        if (combinations.Count == 0)
        {
            string fileText = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Combinations.txt"));

            IEffect effect = null;
            foreach (Match match in Regex.Matches(fileText, @"\s*(.*?)\s(.*?)\s({.*})"))
            {
                Debug.Log(":" + match.Groups[1].Value + " + " + match.Groups[2].Value + " = " + match.Groups[3].Value);

                InteracteeItem item1 = new InteracteeItem(match.Groups[1].Value);
                String interactee = match.Groups[2].Value;
                effect = ParseEffect(match.Groups[3].Value);

                if (interactee.IndexOf('"') != -1)
                {
                    InteracteeDescriptor desc = new InteracteeDescriptor(Descriptor.GetRoot().GetDescriptor(interactee.Replace("\"", "")));
                    combinations.Add(new Combination(item1, desc, effect));
                }
                else
                {
                    InteracteeItem item2 = new InteracteeItem(interactee);
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

    public static IEffect LoadEffect(String effectName, String[] args)
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
            default:
                throw new Exception("Effect not found!");
        }
    }

    public static List<Combination> GetCombinations()
    {
        throw new NotImplementedException();
    }

    public static void Save()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach(Combination combination in combinations){
            combination.ToSafeFormat(stringBuilder);
        }
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