using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScriptP2 : MonoBehaviour {

    Animator anim;
    int chosen;
    public List<GameObject> walking = new List<GameObject>();

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        walking.Add(GameObject.FindGameObjectWithTag("zerk2"));
        walking.Add(GameObject.FindGameObjectWithTag("mage2"));
        walking.Add(GameObject.FindGameObjectWithTag("staby2"));
        walking.Add(GameObject.FindGameObjectWithTag("ranger2"));
        chosen = (game.SP2) - 1;
    }

    void Update()
    {
        walking[chosen].GetComponent<SpriteRenderer>().enabled = true;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {

            anim.SetBool("up", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("down", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("walkingLeft", true);
        }
        else
        {
            anim.SetBool("walkingLeft", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("walkingRight", true);
        }
        else
        {
            anim.SetBool("walkingRight", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("walkingUp", true);
        }
        else
        {
            anim.SetBool("walkingUp", false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("walkingDown", true);
        }
        else
        {
            anim.SetBool("walkingDown", false);
        }

    }
}
