using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class Validator : ScriptableObject
{
    public abstract String GetName();
    public abstract bool ItemMatch(Item interactee);
}
