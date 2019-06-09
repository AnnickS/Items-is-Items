using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideEnterExample : MonoBehaviour
{

    public GameObject popup;

    private void Start()
    {
        popup.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        popup.SetActive(true);
    }
}
