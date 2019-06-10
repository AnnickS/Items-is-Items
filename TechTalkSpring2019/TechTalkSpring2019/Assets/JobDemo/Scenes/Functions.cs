using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour {

    void Awake()
    {
        //Debug.Log("Awake");
    }

    void Start () {
        //Debug.Log("Start");


        /*
        #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 1;
        #endif
        /**/
    }

    void Update () {
        //Debug.Log("Update");
	}

    void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    //Common misconception about FixedUpdate is that its consistent 
    //when in reality it runs as many times as it need to catch up for the next update 
    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }
}
