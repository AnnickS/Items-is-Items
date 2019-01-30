using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogPopup : Dialog
{
    public TextMeshPro textMesh;

    public override void hide()
    {
        this.gameObject.SetActive(false);
    }

    public override bool isShowing()
    {
        return this.gameObject.activeSelf;
    }

    public override void setText(string text)
    {
        textMesh.text = text;
    }

    public override void show()
    {
        this.gameObject.SetActive(true);
    }
}
