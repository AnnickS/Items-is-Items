using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Quest : MonoBehaviour
{

    public Dialog dialog;
    public string text = "Hi I'm flowey";

    void Start()
    {
        dialog.setText(text);
    }

    void OnMouseDown()
    {
        dialog.show();
    }
}
