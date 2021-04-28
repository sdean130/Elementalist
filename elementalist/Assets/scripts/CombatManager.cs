using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

    public Button attackButton, nextButton, prevButton;
    int[] turnOrder = new int[8];
    int[] initiative = new int[8];

    public Text heroHP;
    public Text mageHP;
    public Text tankHP;
    public Text suppHP;
    public Text goonHP;
    public Text goon2HP;
    public Text goon3P;
    public Text goon4P;

    public int prevScene;

    public int HeroI_0;
    public int MageI_1;
    public int TankI_2;
    public int SuppI_3;
    public int goonI_4;
    public int goon2I_5;
    public int goon3I_6;
    public int goon4I_7;

    int incrTurn;
    int curGoing;
    int curTarget;
    int eTarget;

    public bool hasAttacked;

    public enum CombatStates
    {
        START,
        TURN,
        PLAYERCHOICE,
        PREVTARGET,
        NEXTTARGET,
        ENEMYGO,
        CHECKWIN,
        PLAYERWIN,
        ENEMYWIN
    }

    public CombatStates currState;

	void Start () 
    {
        updateHPBars();
        incrTurn = 0;
        curGoing = 0;
        curTarget = 4;
        // roll 100D for initiative
        HeroI_0 = (int)(teamStats.PlayerI * Random.Range(1.0f, 100.0f));
        MageI_1 = (int)(teamStats.MageI * Random.Range(1.0f, 100.0f));
        TankI_2 = (int)(teamStats.TankI * Random.Range(1.0f, 100.0f));
        SuppI_3 = (int)(teamStats.SupportI * Random.Range(1.0f, 100.0f));
        goonI_4 = (int)(.5 * Random.Range(1.0f, 100.0f));
        goon2I_5 = (int)(.5 * Random.Range(1.0f, 100.0f));
        goon3I_6 = (int)(.5 * Random.Range(1.0f, 100.0f));
        goon4I_7 = (int)(.5 * Random.Range(1.0f, 100.0f));

        initiative[0] = HeroI_0;
        initiative[1] = MageI_1;
        initiative[2] = TankI_2;
        initiative[3] = SuppI_3;
        initiative[4] = goonI_4;
        initiative[5] = goon2I_5;
        initiative[6] = goon3I_6;
        initiative[7] = goon4I_7;

        for (int i = 0; i < turnOrder.Length; i++)
        {
            turnOrder[i] = i;
        }

        for (int x = 0; x < turnOrder.Length; x++)
        {
            for (int y = 0; y < turnOrder.Length - x - 1; y++)
            {
                if(initiative[turnOrder[y]] < initiative[turnOrder[y + 1]])
                {
                    int t = turnOrder[y];
                    turnOrder[y] = turnOrder[y + 1];
                    turnOrder[y + 1] = t;
                }
            }
        }

        Button atkBtn = attackButton.GetComponent<Button>();
        Button prvBtn = prevButton.GetComponent<Button>();
        Button nxtBtn = nextButton.GetComponent<Button>();

        nxtBtn.onClick.AddListener(NextChoice);
        prvBtn.onClick.AddListener(PrevChoice);
        atkBtn.onClick.AddListener(Attack);

        hasAttacked = false;

    }

    int CalcPlayerDamage(int deeps, float armor)
    {
        switch (deeps)
        {
            case (1):
                return (int)(teamStats.MagePStat * armor);
            case (2):
                return (int)(teamStats.TankPStat * armor);
            case (3):
                return (int)(teamStats.SupportPStat * armor);
            default:
                return (int)(teamStats.PlayerPStat * armor);
        }
    }

    int CalcPlayerHealthRecovD(int character, float recov)
    {
        switch (character)
        {
            case (1):
                return (int)(teamStats.MageHealth * teamStats.MageHRecov);
            case (2):
                return (int)(teamStats.TankHealth * teamStats.TankHRecov);
            case (3):
                return (int)(teamStats.SupportHealth * teamStats.SupportHRecov);
            default:
                return (int)(teamStats.PlayerHealth * teamStats.PlayerHRecov);
        }
    }

    float FetchPlayerArmor(int character)
    {
        switch (character)
        {
            case (1):
                return teamStats.MageA;
            case (2):
                return teamStats.TankA;
            case (3):
                return teamStats.SupportA;
            default:
                return teamStats.PlayerA;
        }
    }

    float FetchEnemyArmor()
    {
        return EnemyStats.GoonA;
    }


    int CalcEnemyDamage(int character)
    {
        switch (character)
        {
            case (1):
                return (int)(EnemyStats.GoonS * teamStats.MageA);
            case (2):
                return (int)(EnemyStats.GoonS * teamStats.TankA);
            case (3):
                return (int)(EnemyStats.GoonS * teamStats.SupportA);
            default:
                return (int)(EnemyStats.GoonS * teamStats.PlayerA);
        }
    }

    bool CheckEnemyWin()
    {
        if (teamStats.PlayerHealth > 0 || teamStats.MageHealth > 0 || teamStats.TankHealth > 0 || teamStats.SupportHealth > 0)
        {
            return false;
        }
        else { return true; }
    }
    bool CheckPlayerWin()
    {
        if (EnemyStats.GoonHP > 0 || EnemyStats.Goon2HP > 0 || EnemyStats.Goon3HP > 0 || EnemyStats.Goon4HP > 0)
        {
            return false;
        }
        else { return true; }
    }

    void CheckEnemyHP(int enemy)
    {
        switch (enemy)
        {
            case (1):
                if (EnemyStats.Goon2HP <= 0)
                {
                    Debug.Log("goon5 has " + EnemyStats.Goon2HP + " left, skipping");
                    incrTurn++;
                    Debug.Log("turn incr to " + incrTurn);
                    currState = CombatStates.TURN;
                    break;
                }
                break;
            case (2):
                if (EnemyStats.Goon3HP <= 0)
                {
                    Debug.Log("goon6 has " + EnemyStats.Goon3HP + " left, skipping");
                    incrTurn++;
                    Debug.Log("turn incr to " + incrTurn);
                    currState = CombatStates.TURN;
                    break;
                }
                break;
            case (3):
                if (EnemyStats.Goon4HP <= 0)
                {
                    Debug.Log("goon7 has " + EnemyStats.Goon4HP + " left, skipping");
                    incrTurn++;
                    Debug.Log("turn incr to " + incrTurn);
                    currState = CombatStates.TURN;
                    break;
                }
                break;
            default:
                if (EnemyStats.GoonHP <= 0)
                {
                    Debug.Log("goon4 has " + EnemyStats.GoonHP + " left, skipping"); 
                    incrTurn++;
                    Debug.Log("turn incr to " + incrTurn);
                    currState = CombatStates.TURN;
                    break;
                }
                break;
        }
    }

    void CheckPlayerHP(int character)
    {
        switch (character)
        {
            case (1):
                if (teamStats.MageHealth <= 0)
                {
                    Debug.Log("Mage has " + teamStats.MageHealth + " skipping");
                    incrTurn++;
                    Debug.Log("turn incr to " + incrTurn);
                    currState = CombatStates.TURN;
                    break;
                }
                break;
            case (2):
                if (teamStats.TankHealth <= 0)
                {
                    Debug.Log("Tank has " + teamStats.TankHealth + " skipping");
                    incrTurn++;
                    Debug.Log("turn incr to " + incrTurn);
                    currState = CombatStates.TURN;
                    break;
                }
                break;
            case (3):
                if (teamStats.SupportHealth <= 0)
                {
                    Debug.Log("Supp has " + teamStats.SupportHealth + " skipping"); 
                    incrTurn++;
                    Debug.Log("turn incr to " + incrTurn);
                    currState = CombatStates.TURN;
                    break;
                }
                break;
            default:
                if (teamStats.PlayerHealth <= 0)
                {
                    Debug.Log("Hero has " + teamStats.PlayerHealth + " skipping");
                    incrTurn++;
                    Debug.Log("turn incr to " + incrTurn);
                    currState = CombatStates.TURN;
                    break;
                }
                break;
        }
    }


    void EnemyTurn()
    {

        eTarget = (int)Random.Range(0.0f, 3.0f);
        Debug.Log("goon: " + curGoing + " is attacking character" + eTarget);
        Debug.Log(curGoing + " hit character " + eTarget + " for " + CalcEnemyDamage(eTarget));
        switch (eTarget)
        {
            case (1):
                teamStats.MageHealth = teamStats.MageHealth - CalcEnemyDamage(eTarget);
                Debug.Log("mage has " + teamStats.MageHealth + " left");
                break;
            case (2):
                teamStats.TankHealth = teamStats.TankHealth - CalcEnemyDamage(eTarget);
                Debug.Log("Tank has " + teamStats.TankHealth + " left");
                break;
            case (3):
                teamStats.SupportHealth = teamStats.SupportHealth - CalcEnemyDamage(eTarget);
                Debug.Log("Supp has " + teamStats.SupportHealth + " left");
                break;
            default:
                teamStats.PlayerHealth = teamStats.PlayerHealth - CalcEnemyDamage(eTarget);
                Debug.Log("Hero has " + teamStats.PlayerHealth + " left");
                break;
        }
            incrTurn++;
            Debug.Log("turn incr to " + incrTurn);

    }

    void Attack()
    {
        if (!hasAttacked )
        {
            Debug.Log("character: " + curGoing + " is attacking goon " + curTarget);

            Debug.Log(curGoing + " hit goon " + curTarget + " for " + CalcPlayerDamage(curGoing, FetchEnemyArmor()));
            switch (curTarget)
            {
                case (5):
                    EnemyStats.Goon2HP = EnemyStats.Goon2HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                    Debug.Log("goon" + curTarget + " has " + EnemyStats.Goon2HP + " left");
                    break;
                case (6):
                    EnemyStats.Goon3HP = EnemyStats.Goon3HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                    Debug.Log("goon" + curTarget + " has " + EnemyStats.Goon3HP + " left");
                    break;
                case (7):
                    EnemyStats.Goon4HP = EnemyStats.Goon4HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                    Debug.Log("goon" + curTarget + " has " + EnemyStats.Goon4HP + " left");
                    break;
                default:
                    EnemyStats.GoonHP = EnemyStats.GoonHP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                    Debug.Log("goon" + curTarget + " has " + EnemyStats.GoonHP + " left");
                    break;
            }
            incrTurn++;
            Debug.Log("turn incr to " + incrTurn);
            hasAttacked = true;
        }
    }

    void NextChoice()
    {
        if (currState == CombatStates.PLAYERCHOICE)
        {
            currState = CombatStates.NEXTTARGET;
        }
    }

    void PrevChoice()
    {
        if (currState == CombatStates.PLAYERCHOICE)
        {
            currState = CombatStates.PREVTARGET;
        }

    }
    void updateHPBars()
    {
        heroHP.text = "Hero HP: " + teamStats.PlayerHealth;
        mageHP.text = "Tank HP: " + teamStats.TankHealth;
        tankHP.text = "Mage HP: " + teamStats.MageHealth; 
        suppHP.text = "Supp HP: " + teamStats.SupportHealth; 
        goonHP.text = "Goon HP: " + EnemyStats.GoonHP; 
        goon2HP.text = "Goon2 HP: " + EnemyStats.Goon2HP;
        goon3P.text = "Goon3 HP: " + EnemyStats.Goon3HP;
        goon4P.text = "Goon4 HP: " + EnemyStats.Goon4HP;

    }

    void ColorHPTurn(int character)
    {
        switch (character)
        {
            case (1):
                heroHP.color = Color.black;
                mageHP.color = Color.blue;
                tankHP.color = Color.black;
                suppHP.color = Color.black;
                break;
            case (2):
                heroHP.color = Color.black;
                mageHP.color = Color.black;
                tankHP.color = Color.blue;
                suppHP.color = Color.black;

                break;
            case (3):
                heroHP.color = Color.black;
                mageHP.color = Color.black;
                tankHP.color = Color.black;
                suppHP.color = Color.blue;
                break;
            default:
                heroHP.color = Color.blue;
                mageHP.color = Color.black;
                tankHP.color = Color.black;
                suppHP.color = Color.black;
                break;
        }
    }
    void ColorHPTarget(int character)
    {
        switch (character)
        {
            case(5):
                goonHP.color = Color.black;
                goon2HP.color = Color.red;
                goon3P.color = Color.black;
                goon4P.color = Color.black;
                break;
            case (6):
                goonHP.color = Color.black;
                goon2HP.color = Color.black;
                goon3P.color = Color.red;
                goon4P.color = Color.black;

                break;
            case (7):
                goonHP.color = Color.black;
                goon2HP.color = Color.black;
                goon3P.color = Color.black;
                goon4P.color = Color.red;

                break;
            default:
                goonHP.color = Color.red;
                goon2HP.color = Color.black;
                goon3P.color = Color.black;
                goon4P.color = Color.black;
                break;
        }
    }

    // Update is called once per frame
    void Update () 
    {
        Debug.Log(currState);
        updateHPBars();
        ColorHPTurn(curGoing);
        ColorHPTarget(curTarget);
        switch(currState)
        {
            case(CombatStates.START):
                currState = CombatStates.TURN;
                break;
            case(CombatStates.TURN):
                while(incrTurn < turnOrder.Length)
                {
                    if(turnOrder[incrTurn] < 4)
                    {
                        Debug.Log("Character: " + turnOrder[incrTurn] + " rolled: " + initiative[turnOrder[incrTurn]]);
                        curGoing = turnOrder[incrTurn];
                        hasAttacked = false;
                        currState = CombatStates.PLAYERCHOICE;
                        break;

                    }
                    else
                    {
                        Debug.Log("enemy: " + turnOrder[incrTurn] + " rolled: " + initiative[turnOrder[incrTurn]]);
                        curGoing = turnOrder[incrTurn];
                        Debug.Log("curGoing is " + turnOrder[incrTurn]);
                        currState = CombatStates.ENEMYGO;
                        break;
                    }
                }
                if (incrTurn >= 7)
                {
                    currState = CombatStates.CHECKWIN;
                }
                break;

            case(CombatStates.PLAYERCHOICE):
                // CheckPlayerHP(curGoing);
                Debug.Log("current target is: " + curTarget);
                if(hasAttacked)
                {
                    Debug.Log("end of player turn");
                    currState = CombatStates.TURN;
                }
                // Attack();
                // currState = CombatStates.TURN;
                break;
            
            case(CombatStates.ENEMYGO):
                // CheckEnemyHP(curGoing);
                EnemyTurn();
                Debug.Log("end of enemy turn");
                currState = CombatStates.TURN;
                break;

            case(CombatStates.NEXTTARGET):
                if (curTarget <= 6)
                {
                    curTarget++;
                    Debug.Log("current target is: " + curTarget);
                    currState = CombatStates.PLAYERCHOICE;
                    break;
                }
                else if (curTarget == 7)
                {
                    curTarget = 4;
                    Debug.Log("current target is: " + curTarget);
                    currState = CombatStates.PLAYERCHOICE;
                    break;
                }
                break;

            case(CombatStates.PREVTARGET):
                if (curTarget >= 5)
                {
                    curTarget--;
                    Debug.Log("current target is: " + curTarget);
                    currState = CombatStates.PLAYERCHOICE;
                    break;
                }
                else if (curTarget == 4)
                {
                    curTarget = 7;
                    Debug.Log("current target is: " + curTarget);
                    currState = CombatStates.PLAYERCHOICE;
                    break;
                }
                break;

            case(CombatStates.CHECKWIN):
                if (CheckPlayerWin() || CheckEnemyWin())
                {
                    currState = CombatStates.PLAYERWIN;
                }
                else
                {
                    incrTurn = 0;
                    currState = CombatStates.TURN;
                }
                break;

            case(CombatStates.PLAYERWIN):
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

        }
	}
}
