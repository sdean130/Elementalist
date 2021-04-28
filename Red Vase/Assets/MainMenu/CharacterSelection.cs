using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    public GameObject PlayerOnePanel;
    public GameObject PlayerTwoPanel;

    public Sprite Berserker;
    public Sprite Mage;
    public Sprite Polearm;

    public Text playerOneCharacterTitle;
    public Text playerTwoCharacterTitle;

    public Button playButton;

    Image playerOneDisplay;
    Image playerTwoDisplay;

    bool P1Ready;
    bool P2Ready;

    Dictionary<int, string> pStrings = new Dictionary<int, string>();
    Dictionary<int, Sprite> pSprites = new Dictionary<int, Sprite>();

    int P1Selected;
    int P2Selected;

    
    void Start()
    {
        playerOneDisplay = PlayerOnePanel.GetComponent<Image>();
        playerTwoDisplay = PlayerTwoPanel.GetComponent<Image>();

        pStrings.Add(1, "Berserker");
        pStrings.Add(2, "Mage");
        pStrings.Add(3, "Polearm");

        pSprites.Add(1, Berserker);
        pSprites.Add(2, Mage);
        pSprites.Add(3, Polearm);

        P1Selected = 1;
        P2Selected = 2;

        playerOneDisplay.sprite = pSprites[P1Selected];
        playerTwoDisplay.sprite = pSprites[P2Selected];

        playerOneCharacterTitle.text = pStrings[P1Selected];
        playerTwoCharacterTitle.text = pStrings[P2Selected];
    }
    public void PlayerOneLeftClick()
    {
        P1Selected = P1Selected - 1;

        while (P1Selected == P2Selected || P1Selected < 1)
        {
            if (P1Selected < 1)
            {
                P1Selected = 3;
            }
            if (P1Selected == P2Selected)
            {
                P1Selected = P1Selected - 1;
            }
        }
    }
    public void PlayerOneRightClick()
    {
        P1Selected = P1Selected + 1;

        while (P1Selected == P2Selected || P1Selected > 3)
        {
            if (P1Selected > 3)
            {
                P1Selected = 1;
            }
            if (P1Selected == P2Selected)
            {
                P1Selected = P1Selected + 1;
            }
        }

    }
    public void PlayerTwoLeftClick()
    {
        P2Selected = P2Selected - 1;

        while (P2Selected == P1Selected || P2Selected < 1)
        {
            if (P2Selected < 1)
            {
                P2Selected = 3;
            }
            if (P2Selected == P1Selected)
            {
                P2Selected = P2Selected - 1;
            }
        }
    }
    public void PlayerTwoRightClick()
    {
        P2Selected = P2Selected + 1;

        while (P2Selected == P1Selected || P2Selected > 3)
        {
            if (P2Selected > 3)
            {
                P2Selected = 1;
            }
            if (P2Selected == P1Selected)
            {
                P2Selected = P2Selected + 1;
            }
        }

    }

    public void playerOneReadyUp(bool isReady)
    {
        Button[] P1Buttons = PlayerOnePanel.GetComponentsInChildren<Button>();

        if (isReady == true)
        {
            P1Buttons[0].interactable = false;
            P1Buttons[1].interactable = false;
        }

        if (isReady == false)
        {
            P1Buttons[0].interactable = true;
            P1Buttons[1].interactable = true;
        }
        P1Ready = isReady;
    }
    public void playerTwoReadyUp(bool isReady)
    {
        Button[] P2Buttons = PlayerTwoPanel.GetComponentsInChildren<Button>();

        if(isReady == true){
            P2Buttons[0].interactable = false;
            P2Buttons[1].interactable = false;
        }

        if(isReady == false)
        {
            P2Buttons[0].interactable = true;
            P2Buttons[1].interactable = true;
        }
        P2Ready = isReady;
    }

    public void playButtonClick()
    {
        game.SP1 = P1Selected;
        game.SP2 = P2Selected;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Update()
    {
        if (P1Ready && P2Ready)
        {
            playButton.interactable = true;
        }
        if (!P1Ready || !P2Ready)
        {
            playButton.interactable = false;
        }

        playerOneDisplay.sprite = pSprites[P1Selected];
        playerTwoDisplay.sprite = pSprites[P2Selected];

        playerOneCharacterTitle.text = pStrings[P1Selected];
        playerTwoCharacterTitle.text = pStrings[P2Selected];
    }
}
