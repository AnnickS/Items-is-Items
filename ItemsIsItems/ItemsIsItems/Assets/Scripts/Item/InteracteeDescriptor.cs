using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InteracteeDescriptor : IInteractable
{
    public Descriptor descriptor;

    public InteracteeDescriptor(Descriptor descriptor)
    {
        this.descriptor = descriptor;
    }

    public string GetName()
    {
        return descriptor.name;
    }

    public bool ItemMatch(Item interactee)
    {
        if (descriptor == null)
        {
            throw new MissingFieldException("InteracteeDescriptor descriptor is NULL");
        }
        else
        {
            return interactee.HasDescriptor(descriptor);
        }
    }

    public void ToSafeFormat(StringBuilder stringBuilder)
    {
        stringBuilder.Append("\""+GetName()+"\"");
    }
}