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
    /*/
    private static Descriptor ROOT;

    public static Descriptor GetRoot()
    {
        if (ROOT == null)
        {
            ROOT = new Descriptor("ROOT");
            Stack<Descriptor> levelStack = new Stack<Descriptor>();
            levelStack.Push(ROOT);
            string[] lines = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "Descriptor.txt"));
            foreach (string line in lines)
            {
                if (line.IndexOf('{') != -1)
                {
                    levelStack.Push(new Descriptor(line.Substring(0, line.Length - 1), levelStack.Peek()));
                }
                else if (line.IndexOf('}') != -1)
                {
                    levelStack.Pop();
                }
                else
                {
                    new Descriptor(line, levelStack.Peek());
                }
            }
        }
        return ROOT;
    }

    public Descriptor(string name)
    {
        this.name = name;
    }

    public Descriptor(string name, Descriptor parentDescriptor) : this(name)
    {
        parentDescriptor.children.Add(this);
    }/**/

    public static Descriptor GetDescriptor(string name)
    {
        Descriptor d = Resources.Load<Descriptor>("Descriptors/"+name);
        if(d == null)
        {
            throw new FileNotFoundException("Descriptor, "+name+", could not be found!");
        }
        return d;
    }

    public Descriptor GetSubdescriptor(string name)
    {
        Queue<Descriptor> descriptors = new Queue<Descriptor>();
        descriptors.Enqueue(this);

        Descriptor current;
        while (descriptors.Count > 0)
        {
            current = descriptors.Dequeue();
            if (name == current.name)
            {
                return current;
            }
            foreach (Descriptor subdescriptor in current.children)
            {
                descriptors.Enqueue(subdescriptor);
            }
        }
        return null;
    }

    public bool Contains(Descriptor tag)
    {
        Queue<Descriptor> descriptors = new Queue<Descriptor>();
        descriptors.Enqueue(this);

        Descriptor current;
        while (descriptors.Count > 0)
        {
            current = descriptors.Dequeue();
            if (tag.name == current.name)
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

