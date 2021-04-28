using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOffsetScript : MonoBehaviour {

    Vector3 offset;
    public Vector3 p1Position;
    Vector3 p2Position;
    Vector3 midpoint;
	void Start ()
    {// sets the offset to the object that has this scripts position
        p1Position = SelectPlayer1.position;
        p2Position = SelectPlayer2.position;

        midpoint = new Vector3(
            (p1Position.x + p2Position.x)/2, 
            (p1Position.y + p2Position.y)/2, 0);	
        offset = transform.position - midpoint;
    }
	
	void Update ()
    {// adds the above off
        p1Position = SelectPlayer1.position;
        p2Position = SelectPlayer2.position;
        midpoint = new Vector3(
            (p1Position.x + p2Position.x) / 2,
            (p1Position.y + p2Position.y) / 2, 0);
        transform.position = midpoint + offset;
    }
}
