using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {


    // so this is where buttons need to set the selected character values to
    static int selectedP1 = 2;
    static int selectedP2 = 1;

    static bool haveVase;

    static bool isVase;
    static bool isVase2;
    static bool isVase3;
    static bool isVase4;
    static bool isVase5;
    static bool isVase6;

	// Use this for initialization
	void Start ()
    {
        haveVase = false;
        GameObject.FindGameObjectWithTag("zerk").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("zerkAtt").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("staby").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("stabyAtt").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("zerk2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("zerkAtt2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("staby2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("stabyAtt2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("mage").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("mageAtt").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("mage2").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("mageAtt2").GetComponent<SpriteRenderer>().enabled = false;
    }
    public static int SP1
    {
        get { return selectedP1; }
        set { selectedP1 = value; }
    }
    public static int SP2
    {
        get { return selectedP2; }
        set { selectedP2 = value; }
    }
    public static bool HaveVase
    {
        get { return haveVase; }
        set { haveVase = value; }
    }

    public static bool IsVase
    {
        get { return isVase; }
        set { isVase = value; }
    }
    public static bool IsVase2
    {
        get { return isVase2; }
        set { isVase2 = value; }
    }
    public static bool IsVase3
    {
        get { return isVase3; }
        set { isVase3 = value; }
    }
    public static bool IsVase4
    {
        get { return isVase4; }
        set { isVase4 = value; }
    }
    public static bool IsVase5
    {
        get { return isVase5; }
        set { isVase5 = value; }
    }
    public static bool IsVase6
    {
        get { return isVase6; }
        set { isVase6 = value; }
    }
}
