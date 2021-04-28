using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {

    public Button attackButton, nextButton, prevButton;
    int[] turnOrder = new int[8];
    int[] initiative = new int[8];

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

    void EnemyTurn()
    {
        eTarget = (int)Random.Range(0.0f, 3.0f);
        Debug.Log("enemy: " + curGoing + " is attacking character" + eTarget);
        Debug.Log(curGoing + " hit character " + eTarget + " for " + CalcEnemyDamage(eTarget));
        switch(eTarget)
        {
            case(1):
                teamStats.MageHealth = teamStats.MageHealth - CalcEnemyDamage(eTarget);
                Debug.Log("mage has " + teamStats.MageHealth + " left");
                break;
            case(2):
                teamStats.TankHealth = teamStats.TankHealth - CalcEnemyDamage(eTarget);
                Debug.Log("Tank has " + teamStats.TankHealth + " left");
                break;
            case(3):
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
        Debug.Log("character: " + curGoing + " is attacking enemy " + curTarget);

        Debug.Log(curGoing + " hit enemy " + curTarget + " for " + CalcPlayerDamage(curGoing, FetchEnemyArmor()));
        switch(curTarget-4)
        {
            case(1):
                EnemyStats.Goon2HP = EnemyStats.Goon2HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                Debug.Log("goon" + curTarget + " has " + EnemyStats.Goon2HP + " left");
                break;
            case(2):
                EnemyStats.Goon3HP = EnemyStats.Goon3HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                Debug.Log("goon" + curTarget + " has " + EnemyStats.Goon3HP + " left");
                break;
            case(3):
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

    // Update is called once per frame
    void Update () 
    {
        Debug.Log(currState);
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
                        Debug.Log("curGoing is " + curGoing);
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
                if (incrTurn == 8)
                {
                    currState = CombatStates.CHECKWIN;
                }
                break;

            case(CombatStates.PLAYERCHOICE):
                Debug.Log("current target is: " + curTarget);
                if(hasAttacked)
                {
                    currState = CombatStates.TURN;
                }
                // Attack();
                // currState = CombatStates.TURN;
                break;
            
            case(CombatStates.ENEMYGO):
                EnemyTurn();
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

        }
	}
}
