using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackAnimationP2 : MonoBehaviour {

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

        attacks.Add(GameObject.FindGameObjectWithTag("zerkAtt2"));
        attacks.Add(GameObject.FindGameObjectWithTag("mageAtt2"));
        attacks.Add(GameObject.FindGameObjectWithTag("stabyAtt2"));
        attacks.Add(GameObject.FindGameObjectWithTag("rangerAtt2"));

        chosenOne = (game.SP2) - 1;
        GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
            left = false;
            up = false;
            down = false;
            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            if (Input.GetKey(KeyCode.RightShift))
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
                if(chosenOne == 1)
                {
                    GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = true;
                }

                anim.SetBool("attackRight", true);
            }
            else
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = false;
                anim.SetBool("attackRight", false);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            right = false;
            left = true;
            up = false;
            down = false;
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            if (Input.GetKey(KeyCode.RightShift))
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
                if (chosenOne == 1)
                {
                    GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = true;
                }
                anim.SetBool("attackLeft", true);
            }
            else
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = false;
                anim.SetBool("attackLeft", false);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            right = false;
            left = false;
            up = true;
            down = false;
            anim.SetBool("up", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
            if (Input.GetKey(KeyCode.RightShift))
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
                if (chosenOne == 1)
                {
                    GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = true;
                }
                anim.SetBool("attackUp", true);
            }
            else
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = false;

                anim.SetBool("attackUp", false);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            right = false;
            left = false;
            up = false;
            down = true;
            anim.SetBool("down", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            if (Input.GetKey(KeyCode.RightShift))
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
                if (chosenOne == 1)
                {
                    GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = true;
                }
                anim.SetBool("attackDown", true);
            }
            else
            {
                attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = false;
                anim.SetBool("attackDown", false);
            }
        }

        if (Input.GetKey(KeyCode.RightShift) && right)
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = true;
            }
            anim.SetBool("attackRight", true);
        }
        else if (Input.GetKey(KeyCode.RightShift) && left)
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = true;
            }
            anim.SetBool("attackLeft", true);
        }
        else if (Input.GetKey(KeyCode.RightShift) && up)
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = true;
            }
            anim.SetBool("attackUp", true);
        }
        else if (Input.GetKey(KeyCode.RightShift) && down)
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = true;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = true;
            }
            anim.SetBool("attackDown", true);
        }
        else
        {
            attacks[chosenOne].GetComponent<SpriteRenderer>().enabled = false;
            if (chosenOne == 1)
            {
                GameObject.FindGameObjectWithTag("spell2").GetComponent<SpriteRenderer>().enabled = false;
            }
            anim.SetBool("attackRight", false);
            anim.SetBool("attackLeft", false);
            anim.SetBool("attackUp", false);
            anim.SetBool("attackDown", false);
        }

    }
}
