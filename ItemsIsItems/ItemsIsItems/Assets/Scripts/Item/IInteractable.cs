using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public interface IInteractable
{
    String GetName();
    bool ItemMatch(Item interactee);
    void ToSafeFormat(StringBuilder stringBuilder);
}
