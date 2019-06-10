using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour {

    public int number = 0;

    void Start()
    {
        StartCoroutine(Coroutine());   
    }

    void Update()
    {
        Debug.Log("Update");
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            Debug.Log("Coroutine");
            yield return null;
            //yield return new WaitForSeconds(1);
            //yield return new WaitUntil(() => number >= 5);
        }
    }
}
