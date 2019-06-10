using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listeners : MonoBehaviour {

    void OnDestroy()
    {
        Debug.Log("Destroyed");
    }

    void OnDisable()
    {
        Debug.Log("Disabled");
    }

    void OnEnable()
    {
        Debug.Log("Enabled");
    }    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(1,1,1));
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
    }

    void OnGUI()
    {
        //Debug.Log("OnGUI");
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
        {
            print("button clicked");
        }
    }

}
