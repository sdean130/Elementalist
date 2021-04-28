using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOffsetScript : MonoBehaviour {

    public static Vector3 offset;

	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        offset = this.transform.position - Player.position;	
	}
	
	void Update ()
    {
        // adds the above offset
        this.transform.position = Player.position + offset;
    }
    
}
