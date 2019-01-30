using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialog : MonoBehaviour
{
    public abstract bool isShowing();
    public abstract void show();
    public abstract void setText(string text);
    public abstract void hide();
}
