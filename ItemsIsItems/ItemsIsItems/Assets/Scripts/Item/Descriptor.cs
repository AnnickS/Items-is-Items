using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(menuName = "Descriptor")]
public class Descriptor : ScriptableObject
{
    public List<Descriptor> children = new List<Descriptor>();

    public bool Contains(Descriptor tag)
    {
        Queue<Descriptor> descriptors = new Queue<Descriptor>();
        descriptors.Enqueue(this);

        Descriptor current;
        while (descriptors.Count > 0)
        {
            current = descriptors.Dequeue();
            if (tag == current)
            {
                return true;
            }
            foreach(Descriptor subdescriptor in current.children)
            {
                descriptors.Enqueue(subdescriptor);
            }
        }
        return false;
    }

    public static string PrintDescriptorTree()
    {
        Descriptor[] all = Resources.LoadAll<Descriptor>("Descriptors");
        List<Descriptor> tier1 = all.ToList<Descriptor>();

        foreach (Descriptor d in all)
        {
            foreach (Descriptor inside in d.children)
            {
                tier1.Remove(inside);
            }
        }

        Descriptor ROOT = ScriptableObject.CreateInstance<Descriptor>();
        ROOT.name = "ROOT";
        ROOT.children = tier1;
        string tree = ROOT.ToStringRecursive();
        Destroy(ROOT);

        return tree;
    }

    public string ToStringRecursive()
    {
        StringBuilder builder = new StringBuilder();
        ToStringRecursive(this, builder, 0);

        return builder.ToString();
    }

    private void ToStringRecursive(Descriptor current, StringBuilder builder, int depth)
    {
        for (int i = 0; i < depth; i++)
        {
            builder.Append("\t");
        }
        builder.Append(current.name + (current.children.Count > 0 ? ":" : "") + "\n");
        foreach (Descriptor subdescriptor in current.children)
        {
            ToStringRecursive(subdescriptor, builder, depth + 1);
        }
    }

    public override string ToString()
    {
        return name;
    }
}

