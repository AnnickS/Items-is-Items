using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Quest : MonoBehaviour
{
    private double timeLeft = 0;
    public double timeOnScreen = 1.0;

    public SpriteRenderer spriteRenderer;
    private Color colorNormal;
    private Color colorRunning = Color.yellow;

    public TextMeshPro textMesh;
    public string text = "Hi I'm flowey";

    void Start()
    {
        colorNormal = spriteRenderer.color;
    }
    
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            Debug.Log("Running");
            spriteRenderer.color = colorRunning;
            textMesh.text = text;
            textMesh.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("No Running");
            spriteRenderer.color = colorNormal;
            textMesh.text = "";
            textMesh.gameObject.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        timeLeft = timeOnScreen;
        Debug.Log("Mouse Down");
    }
}
