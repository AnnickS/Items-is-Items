using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowGameObject : MonoBehaviour
{

    public GameObject gameObjectToFollow;

    // Use this for initialization
    void Start()
    {
        if (gameObjectToFollow == null)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        float newXPosition = gameObjectToFollow.transform.position.x;
        float newYPosition = gameObjectToFollow.transform.position.y;
        float oldZPosition = this.transform.position.z;

        this.transform.position = new Vector3(newXPosition, newYPosition, oldZPosition);
    }
}
