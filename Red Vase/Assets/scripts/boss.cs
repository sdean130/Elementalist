using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour {

    public int maxTension;
    public int curTension;
    public bool intro;
    public bool vase1;
    bool vase2;
    bool vase3;
    bool vase4;

    public bool GuiOn;
    public string curDialogue;
    Rect BoxSize = new Rect(0, 0, 300, 300);
    public GUISkin customSkin;
    game g = new game();

    public string Intro;
    public string v1;
    string v2;
    string v3;
    string v4;

    public Slider tensionSlider;

	// Use this for initialization
	void Start () 
    {
        maxTension = 4;
        curTension = 0;
        intro = true;
        vase1 = false;
        vase2 = false;
        vase3 = false;
        vase4 = false;

        GuiOn = false;

        Intro = "You're probably wondering what you're doing here. Well It doesn't matter, just do me a favor and go grab the vase from the room over, bring it back and I'll show you the way out.";
        v1 = "No, that is not the vase.  How hard is it to find the vase? Just go back and bring me the vase!";
        v2 = "Are you deaf? I said bring me the vase. One vase to rule them all, one vase to find them, one vase to bring them all and in the darkness bind them. Now go get the vase.";
        v3 = "Are you really going to make me find the vase? It's not hard, just find the vase and bring it to me and I'll let you out. >:(";
        v4 = "Alright that is it, no more games. If you will not bring me the vase you shall parish. Begon thots.";

	}
	void Update()
    {
        if (curTension == 0)
        {
            intro = true;
            vase1 = false;
        }else
        if (curTension == 1)
        {
            vase1 = true;
            intro = false;
            }else
        if (curTension == 2)
        {
            vase2 = true;
            vase1 = false;
            intro = false;
                }else
        if (curTension == 3)
        {
            vase3 = true;
            vase2 = false;
            vase1 = false;
            intro = false;
        }else
        if (curTension == maxTension)
        {
            vase4 = true;
            vase3 = false;
            vase2 = false;
            vase1 = false;
            intro = false;
        }

        tensionSlider.value = curTension;
	}
	void OnTriggerEnter2D(Collider2D C)
	{
        if( gameObject.tag == "boss" && C.gameObject == GameObject.FindGameObjectWithTag("Player") || C.gameObject == GameObject.FindGameObjectWithTag("player2"))
        {

            if (game.HaveVase)
            {
                game.HaveVase = false;
                curTension += 1;
            }
            GuiOn = true;
            if (intro)
            {
                curDialogue = Intro;
            }
            else if (vase1)
            {
                curDialogue = v1;
            }
            else if (vase2)
            {
                curDialogue = v2;
            }
            else if (vase3)
            {
                curDialogue = v3;
            }
            else if (vase4)
            {
                curDialogue = v4;
            }
        }
        if (!game.HaveVase && gameObject.tag == "vase" && (C.gameObject == GameObject.FindGameObjectWithTag("Player") || C.gameObject == GameObject.FindGameObjectWithTag("player2")))
        {
            GuiOn = true;
            game.IsVase = true;
            if (C.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
                curDialogue = "pick Up vase?(f)";
            }
            else if (C.gameObject == GameObject.FindGameObjectWithTag("player2"))
            {
                curDialogue = "pick Up vase?(m)";
            }
        }if (!game.HaveVase && gameObject.tag == "vase2" && (C.gameObject == GameObject.FindGameObjectWithTag("Player") || C.gameObject == GameObject.FindGameObjectWithTag("player2")))
        {
            GuiOn = true;
            game.IsVase2 = true;
            if (C.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
                curDialogue = "pick Up vase?(f)";
            }
            else if (C.gameObject == GameObject.FindGameObjectWithTag("player2"))
            {

                curDialogue = "pick Up vase?(m)";
            }
        }if (!game.HaveVase && gameObject.tag == "vase3" && (C.gameObject == GameObject.FindGameObjectWithTag("Player") || C.gameObject == GameObject.FindGameObjectWithTag("player2")))
        {
            GuiOn = true;
            game.IsVase3 = true;
            if (C.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
                curDialogue = "pick Up vase?(f)";
            }
            else if (C.gameObject == GameObject.FindGameObjectWithTag("player2"))
            {

                curDialogue = "pick Up vase?(m)";
            }
        }if (!game.HaveVase && gameObject.tag == "vase4" && (C.gameObject == GameObject.FindGameObjectWithTag("Player") || C.gameObject == GameObject.FindGameObjectWithTag("player2")))
        {
            GuiOn = true;
            game.IsVase4 = true;
            if (C.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
                curDialogue = "pick Up vase?(f)";
            }
            else if (C.gameObject == GameObject.FindGameObjectWithTag("player2"))
            {

                curDialogue = "pick Up vase?(m)";
            }
        }if (!game.HaveVase && gameObject.tag == "vase5" && (C.gameObject == GameObject.FindGameObjectWithTag("Player") || C.gameObject == GameObject.FindGameObjectWithTag("player2")))
        {
            GuiOn = true;
            game.IsVase5 = true;
            if (C.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
                curDialogue = "pick Up vase?(f)";
            }
            else if (C.gameObject == GameObject.FindGameObjectWithTag("player2"))
            {

                curDialogue = "pick Up vase?(m)";
            }
        }if (!game.HaveVase && gameObject.tag == "vase6" && (C.gameObject == GameObject.FindGameObjectWithTag("Player") || C.gameObject == GameObject.FindGameObjectWithTag("player2")))
        {
            GuiOn = true;
            game.IsVase6 = true;
            if (C.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
                curDialogue = "pick Up vase?(f)";
            }
            else if (C.gameObject == GameObject.FindGameObjectWithTag("player2"))
            {

                curDialogue = "pick Up vase?(m)";
            }
        }

	}

	void OnTriggerExit2D(Collider2D C)
	{
        if(C.gameObject == GameObject.FindGameObjectWithTag("Player") || C.gameObject == GameObject.FindGameObjectWithTag("player2"))
        {
            GuiOn = false;
            game.IsVase = false;
            game.IsVase2 =false;
            game.IsVase3 = false;
            game.IsVase4 = false;
            game.IsVase5 = false;
            game.IsVase6 = false;
        }

	}

	void OnGUI()
	{
        if(customSkin != null)
        {
            GUI.skin = customSkin;
        }
        if(GuiOn)
        {
            GUI.BeginGroup(new Rect((Screen.width - BoxSize.width), (Screen.height - BoxSize.height), BoxSize.width, BoxSize.height));

            GUI.Label(BoxSize, curDialogue);

            GUI.EndGroup();
        }
	}
}
