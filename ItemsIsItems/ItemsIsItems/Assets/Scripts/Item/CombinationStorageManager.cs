using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public static class CombinationStorageManager
{
    private static List<Combination> combinations = new List<Combination>();

    public static List<Combination> Load()
    {
        string fileText = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Combinations.txt"));

        //MatchCollection match = Regex.Matches(fileText, @"(.*?)\s(.*?)\s({.*})");

        foreach(Match match in Regex.Matches(fileText, @"\s*(.*?)\s(.*?)\s({.*})"))
        {
            Debug.Log(":"+match.Groups[1].Value+ " + " + match.Groups[2].Value+" = " + match.Groups[3].Value);
            //IEffect effect = ParseEffect(match.Groups[3].Value);
            ParseEffect(match.Groups[3].Value);
        }

        /*for(int i = 0; i < lines.Length; i++)
        {
            foreach(Match match in Regex.Matches(lines[0], @"(\w*?)\b(\w*?)\b({.*?})")){

            }

            
            String[] args = lines[i].Split();
            String item1 = args[0];

            String[] effectArgs = new String[args.Length-3];
            Array.Copy(args, effectArgs, effectArgs.Length);

            IEffect effect = LoadEffect(args[3], effectArgs);

        /*
            if (args[1].IndexOf('"') != -1)
            {
                Descriptor desc = Descriptor.GetRoot().GetDescriptor(args[1].Replace("\"", " "));
                combinations.Add(new GeneralItemCombination(item1, desc, effect));
            }
            else
            {
                combinations.Add(new ItemCombination(item1, args[1], effect));
            }
        }*/


        throw new NotImplementedException();
    }

    private static void ParseEffect(String s)
    {
        //IEffect effect;
        Match m = Regex.Match(s, @"{(?:\s*({.*?}|.+?(?=[\s}])))*}");
        String ss = "";
        for(int i = 0; i < m.Groups[1].Captures.Count; i++)
        {
            ss += " '" +m.Groups[1].Captures[i].Value+"'";
        }
        Debug.Log(ss);
        /*
        foreach(Match match in Regex.Matches(s, @"(.*?)*"))
        {
        
            String effectName = match.Groups[1].Value;
            if (effectName == "Multi")
            {
                IEffect[] effects = 
                effect = new EffectMultipleEffects();
            }
            else {
                effect = LoadEffect(effectName, String[] args);
            }
        }*/
        //return effect;
    }

    public static IEffect LoadEffect(String effectName, String[] args)
    {
        switch (effectName)
        {
            case "Spawn":
                return new EffectSpawn().LoadArgs(args);
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