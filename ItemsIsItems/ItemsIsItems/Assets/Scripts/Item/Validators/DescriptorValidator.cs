using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Validator/Descriptor")]
public class DescriptorValidator : Validator
{
    public Descriptor descriptor;

    public override string GetName()
    {
        return descriptor.name;
    }

    public override bool ValidateItem(Item item)
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
}