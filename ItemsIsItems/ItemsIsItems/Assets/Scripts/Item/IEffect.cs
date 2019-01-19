using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect {
    void Execute(Item sender, Item interactor);
}
