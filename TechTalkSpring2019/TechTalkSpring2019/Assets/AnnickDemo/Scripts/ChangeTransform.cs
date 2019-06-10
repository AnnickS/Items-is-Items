using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class ChangeTransform : MonoBehaviour {
    //**Properties**
    //[SerializeField]
    private int experience = 0;

    public int Level
    {
        get
        {
            return experience / 1000;
        }
        set
        {
            experience = value * 1000;
        }
    }

    // Use this for initialization
    void Start () {
        //**GameObject**
        Destroy(this);
        //Destroy(gameObject);
        //Destroy(GetComponent<BoxCollider2D>());

        //**Transform**
        /*
        transform.position = new Vector3(-2, 2);
        transform.rotation = new Quaternion(0, 0, 50, 0);
        transform.localScale = new Vector3(4, 4, 0);
        */

        //**GetComponent**
        /*
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.simulated = true;
        */
    }
}
