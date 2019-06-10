using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGetButtonDownExample : MonoBehaviour
{
    public string exampleButtonName = "ExampleButton";

    public Color startColor = Color.white;
    public Color enterColor = Color.green;
    public Color overColor = Color.cyan;
    public Color exitColor = Color.blue;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.color = startColor;
    }

    void Update()
    {
        if(Input.GetButtonDown(exampleButtonName))
        {
            Debug.Log("GetButtonDown");
            sprite.color = enterColor;
        }

        if(Input.GetButton(exampleButtonName))
        {
            Debug.Log("GetButton");
            sprite.color = overColor;
        }

        if(Input.GetButtonUp(exampleButtonName))
        {
            Debug.Log("GetButtonUp");
            sprite.color = exitColor;
        }
    }
}
