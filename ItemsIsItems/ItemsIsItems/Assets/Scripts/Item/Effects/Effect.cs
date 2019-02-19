using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class Effect : ScriptableObject{
    public abstract void Execute(Item sender, Item interactor);
}
