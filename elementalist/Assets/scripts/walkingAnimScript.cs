using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingAnimScript : MonoBehaviour {

    Animator anim;
    
    int upDown;
    int leftRight;


	void Start () 
    {
        anim = this.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        upDown = (int)Input.GetAxisRaw("Vertical");
        leftRight = (int)Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.D) || leftRight == 1)
        {
            anim.SetBool("left", false);
            anim.SetBool("right", true);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.A) || leftRight == -1)
        {

            anim.SetBool("right", false);
            anim.SetBool("left", true);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.W) || upDown == 1)
        {

            anim.SetBool("up", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.S) || upDown == -1)
        {
            anim.SetBool("down", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
        }

        if (Input.GetKey(KeyCode.D) || leftRight == 1)
        {
            anim.SetBool("walkingRight", true);
        }
        else
        {
            anim.SetBool("walkingRight", false);
        }
        if (Input.GetKey(KeyCode.A) || leftRight == -1)
        {
            anim.SetBool("walkingLeft", true);
        }
        else
        {
            anim.SetBool("walkingLeft", false);
        }
        if (Input.GetKey(KeyCode.W) || upDown == 1)
        {
            anim.SetBool("walkingUp", true);
        }
        else
        {
            anim.SetBool("walkingUp", false);
        }
        if (Input.GetKey(KeyCode.S) || upDown == -1)
        {
            anim.SetBool("walkingDown", true);
        }
        else
        {
            anim.SetBool("walkingDown", false);
        }

    }
}
