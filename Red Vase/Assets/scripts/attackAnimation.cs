using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackAnimation : MonoBehaviour {

    Animator anim;

    bool right;
    bool left;
    bool up;
    bool down;
    int chosenOne;

    public List<GameObject> attacks = new List<GameObject>();

    void Start()
	{
        anim = gameObject.GetComponent<Animator>();

        attacks.Add(GameObject.FindGameObjectWithTag("zerkAtt"));
        attacks.Add(GameObject.FindGameObjectWithTag("mageAtt"));
        attacks.Add(GameObject.FindGameObjectWithTag("stabyAtt"));
        attacks.Add(GameObject.FindGameObjectWithTag("rangerAtt"));

        chosenOne = (game.SP1) - 1;
        GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = false;
	}
	void Update () 
    {
        if (Input.GetKey(KeyCode.D))
        {   
            right = true;
            left = false;
            up = false;
            down = false;
            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            if(Input.GetKey(KeyCode.E))
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
                if (chosenOne == 1)
                {
                    GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = true;
                }
                anim.SetBool("attackRight", true);
            }
            else
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = false;
                anim.SetBool("attackRight", false);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            right = false;
            left = true;
            up = false;
            down = false;
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            if (Input.GetKey(KeyCode.E))
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
                if (chosenOne == 1)
                {
                    GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = true;
                }
                anim.SetBool("attackLeft", true);
            }
            else
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = false;
                anim.SetBool("attackLeft", false);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            right = false;
            left = false;
            up = true;
            down = false;
            anim.SetBool("up", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
            if (Input.GetKey(KeyCode.E))
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
                if (chosenOne == 1)
                {
                    GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = true;
                }
                anim.SetBool("attackUp", true);
            }
            else
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = false;
                anim.SetBool("attackUp", false);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            right = false;
            left = false;
            up = false;
            down = true;
            anim.SetBool("down", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            if (Input.GetKey(KeyCode.E))
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
                if (chosenOne == 1)
                {
                    GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = true;
                }
                anim.SetBool("attackDown", true);
            }
            else
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = false;
                anim.SetBool("attackDown", false);
            }
        }

        if (Input.GetKey(KeyCode.E) && right)
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = true;
            }
            anim.SetBool("attackRight", true);
        }else if (Input.GetKey(KeyCode.E) && left)
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = true;
            }
            anim.SetBool("attackLeft", true);
        }else if (Input.GetKey(KeyCode.E) && up)
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = true;
            }
            anim.SetBool("attackUp", true);
        }else if (Input.GetKey(KeyCode.E) && down)
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = true;
            }
            anim.SetBool("attackDown", true);
        }
        else
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("spell").GetComponent<SpriteRenderer>().enabled = false;
            anim.SetBool("attackRight", false);
            anim.SetBool("attackLeft", false);
            anim.SetBool("attackUp", false);
            anim.SetBool("attackDown", false);
        }

	}
}
