using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Quest : MonoBehaviour
{
    private double timeLeft = 0;
    public double timeOnScreen = 1.0;

    public Dialog dialog;
    public string text = "Hi I'm flowey";
    
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            if( ! dialog.isShowing())
            {
                dialog.show();
                dialog.setText(text);
            }
        }
        else
        {
            dialog.hide();
        }
    }

    void OnMouseDown()
    {
        timeLeft = timeOnScreen;
    }
}
