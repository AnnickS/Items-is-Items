﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogPopup : Dialog
{
    protected TextMeshPro textMesh;
    public Color textColor = Color.black;
    private double timeLeft = 0;
    public double timeOnScreen = 1.0;

    void Awake()
    {
        textMesh = this.gameObject.GetComponentInChildren<TextMeshPro>();
        if (textMesh == null)
        {
            Debug.LogError("DialogPopup Object could not find TextMeshPro Child");
        }
    }

    void Start()
    {
        textMesh.color = textColor;
        hide();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            hide();
        }
    }

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
        timeLeft = timeOnScreen;
    }

    public string getText()
    {
        return textMesh.text;
    }
}
