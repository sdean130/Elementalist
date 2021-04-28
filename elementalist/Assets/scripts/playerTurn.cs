using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTurn : MonoBehaviour {

    Vector3 dir;
    Vector3 e1Position;
    Vector3 e2Position;
    Vector3 e3Position;
    Vector3 e4Position;

    void  Start () 
    {
        e1Position = new Vector3(-5.414f,1.35f,-.1f);
	}
    static Vector3 Position;
    public static Vector3 position
    {
        get { return Position; }
        set { Position = value; }
    }
    void FixedUpdate()
    {
        position = this.transform.position;

        dir = e1Position - position;
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position = e1Position;
        }
    }
    // Update is called once per frame
    void Update () 
    {

    }
}
