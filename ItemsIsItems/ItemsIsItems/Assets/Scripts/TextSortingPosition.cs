using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSortingPosition : MonoBehaviour {
    private Vector3 pos;
    private Quaternion rot;

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().sortingLayerName = "UI";
        pos = transform.position;
        rot = transform.rotation;
    }

    private void Update()
    {
        transform.position = pos;
        transform.rotation = rot;
    }


}
