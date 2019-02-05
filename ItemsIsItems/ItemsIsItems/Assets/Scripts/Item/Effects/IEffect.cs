using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public interface IEffect {
    void Execute(Item sender, Item interactor);
    IEffect LoadArgs(System.Object[] args);
    void ToSafeFormat(StringBuilder stringBuilder);
}
