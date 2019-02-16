using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class Effect : ScriptableObject{
    public abstract void Execute(Item sender, Item interactor);
    public abstract Effect LoadArgs(System.Object[] args);
    public abstract void ToSafeFormat(StringBuilder stringBuilder);
}
