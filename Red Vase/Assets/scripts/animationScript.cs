using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour {

    Animator anim;

    public List<GameObject> walking = new List<GameObject>();
    int chosen;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        walking.Add(GameObject.FindGameObjectWithTag("zerk"));
        walking.Add(GameObject.FindGameObjectWithTag("mage"));
        walking.Add(GameObject.FindGameObjectWithTag("staby"));
        walking.Add(GameObject.FindGameObjectWithTag("ranger"));

        chosen = (game.SP1) - 1;
    }

    void Update()
    {
        walking[chosen].GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.A))
        {

            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.W))
        {

            anim.SetBool("up", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("down", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walkingLeft", true);
        }
        else
        {
            anim.SetBool("walkingLeft", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("walkingRight", true);
        }
        else
        {
            anim.SetBool("walkingRight", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walkingUp", true);
        }
        else
        {
            anim.SetBool("walkingUp", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walkingDown", true);
        }
        else
        {
            anim.SetBool("walkingDown", false);
        }

    }
}
