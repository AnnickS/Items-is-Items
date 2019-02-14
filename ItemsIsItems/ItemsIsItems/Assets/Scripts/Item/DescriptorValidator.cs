using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Combination/Validator/Descriptor")]
public class DescriptorValidator : Validator
{
    public Descriptor descriptor;

    public DescriptorValidator(Descriptor descriptor)
    {
        this.descriptor = descriptor;
    }

    public override string GetName()
    {
        return descriptor.name;
    }

    public override bool ItemMatch(Item interactee)
    {
        if (descriptor == null)
        {
            throw new MissingFieldException("DescriptorValidator descriptor is NULL");
        }
        else
        {
            return interactee.HasDescriptor(descriptor);
        }
    }

    public override void ToSafeFormat(StringBuilder stringBuilder)
    {
        stringBuilder.Append("\""+GetName()+"\"");
    }
}