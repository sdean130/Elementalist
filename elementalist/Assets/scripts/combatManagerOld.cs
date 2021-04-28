using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class combatManagerOld : MonoBehaviour
{

    public Button attackBtn;
    public Button previousBtn, nextBtn;

    // public Toggle enemy1Tog, enemy2Tog, enemy3Tog, enemy4Tog;

    int[] turn = new int[8];
    int[] initiative = new int[8];

    public int pI;
    public int tankI;
    public int mageI;
    public int SI;
    public int E1I;
    public int E2I;
    public int E3I;
    public int E4I;

    int turnInc = 0;
    int curGoing = 0;
    int curTarget;
    int eTarget;

    public enum CombatStates
    {
        start,
        Turn,
        playerChoice,
        prevTarget,
        nextTarget,
        enemyGo,
        checkWin,
        enemyWin,
        playerWin,
    }

    //private CombatStates currState;
    public CombatStates currState;

    // Use this for initialization
    void Start()
    {
        // roll a d100 for initiative
        pI = (int)(teamStats.PlayerI * Random.Range(1.0f, 100.0f));
        tankI = (int)(teamStats.MageI * Random.Range(1.0f, 100.0f));
        mageI = (int)(teamStats.TankI * Random.Range(1.0f, 100.0f));
        SI = (int)(teamStats.SupportI * Random.Range(1.0f, 100.0f));
        E1I = (int)(.5 * Random.Range(1.0f, 100.0f));
        E2I = (int)(.5 * Random.Range(1.0f, 100.0f));
        E3I = (int)(.5 * Random.Range(1.0f, 100.0f));
        E4I = (int)(.5 * Random.Range(1.0f, 100.0f));

        initiative[0] = pI;
        initiative[1] = tankI;
        initiative[2] = mageI;
        initiative[3] = SI;
        initiative[4] = E1I;
        initiative[5] = E2I;
        initiative[6] = E3I;
        initiative[7] = E4I;


        Button atkBtn = attackBtn.GetComponent<Button>();
        Button nxtBtn = nextBtn.GetComponent<Button>();
        Button prvBtn = previousBtn.GetComponent<Button>();

        atkBtn.onClick.AddListener(AttackChoice);
        nxtBtn.onClick.AddListener(NextChoice);
        prvBtn.onClick.AddListener(PreviousChoice);


        for (int i = 0; i < turn.Length; i++)
        {
            turn[i] = i;
        }
        // sort turns
        for (int x = 0; x < turn.Length - 1; x++)
        {
            for (int y = 0; y < turn.Length - x - 1; y++)
            {
                if (initiative[turn[y]] < initiative[turn[y + 1]])
                {
                    int t = turn[y];
                    turn[y] = turn[y + 1];
                    turn[y + 1] = t;
                }
            }
        }
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


    void AttackChoice()
    {
     /*
        if (currState == CombatStates.playerChoice)
        {
            Debug.Log(curGoing + " has gone");

            Debug.Log(curGoing + " has attacked enemy: " + curTarget + " for "
                      + CalcPlayerDamage(curGoing, FetchEnemyArmor()));
            switch (curTarget - 4)
            {
                case (1):
                    EnemyStats.Goon2HP = EnemyStats.Goon2HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                    Debug.Log("Goon2 has " + EnemyStats.Goon2HP + " Left ");
                    break;
                case (2):
                    EnemyStats.Goon3HP = EnemyStats.Goon3HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                    Debug.Log("Goon3 has " + EnemyStats.Goon3HP + " Left ");
                    break;
                case (3):
                    EnemyStats.Goon4HP = EnemyStats.Goon4HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                    Debug.Log("Goon4 has " + EnemyStats.Goon4HP + " Left ");
                    break;
                default:
                    EnemyStats.GoonHP = EnemyStats.GoonHP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                    Debug.Log("Goon has " + EnemyStats.GoonHP + " Left ");
                    break;
            }
        turnInc++;
            Debug.Log("turn inc to " + turnInc);
            currState = CombatStates.Turn;
        }*/
    }

    void NextChoice()
    {
        /*
        if (currState == CombatStates.playerChoice)
        {
            currState = CombatStates.nextTarget;
        }
        */
    }

    void PreviousChoice()
    {
        /*
        if (currState == CombatStates.playerChoice)
        {
            currState = CombatStates.prevTarget;
        }
        */
    }

    void EnemyTurn()
    {
        Debug.Log(curGoing + " has gone");
        /*
                eTarget = (int)Random.Range(0.0f, 3.0f);
                Debug.Log(curGoing + " has attacked: " + eTarget + " for " + CalcEnemyDamage(eTarget));
                switch(eTarget)
                {
                    case (1):
                        teamStats.MageHealth = teamStats.MageHealth - CalcEnemyDamage(eTarget);
                        Debug.Log("mage has " + teamStats.MageHealth + " Left ");
                        break;
                    case (2):
                        teamStats.TankHealth = teamStats.TankHealth - CalcEnemyDamage(eTarget);
                        Debug.Log("tank has " + teamStats.TankHealth + " Left ");
                        break;
                    case (3):
                        teamStats.SupportHealth = teamStats.SupportHealth - CalcEnemyDamage(eTarget);
                        Debug.Log("support has " + teamStats.SupportHealth + " Left ");
                        break;
                    default:
                        teamStats.PlayerHealth = teamStats.PlayerHealth - CalcEnemyDamage(eTarget);
                        Debug.Log("hero has " + teamStats.PlayerHealth + " Left ");
                        break;
                }*/
    }

    void Update()
    {
        Debug.Log(currState);
        switch (currState)
        {
            case (CombatStates.start):
                turnInc = 0;
                currState = CombatStates.Turn;
                break;

            case (CombatStates.Turn):
                Debug.Log(turnInc + " __ " + turn[turnInc] + " __ " + initiative[turn[turnInc]]);
                /*
                while(turnInc < turn.Length)
                {
                    if (turn[turnInc] < 4)
                    {
                        currState = CombatStates.playerChoice;
                        curGoing = turn[turnInc];
                        Debug.Log("player: " + turn[turnInc]);
                        Debug.Log("roll: " + initiative[turn[turnInc]]);
                        break;
                    }
                    else if (turn[turnInc] >= 4)
                    {
                        currState = CombatStates.enemyGo;
                        curGoing = turn[turnInc];
                        Debug.Log("Enemy: " + turn[turnInc]);
                        Debug.Log("roll: " + initiative[turn[turnInc]]);
                        break;
                    }
                }

                if (turnInc == 8)
                {
                    //currState = CombatStates.checkWin;
                }*/
                break;

            case (CombatStates.playerChoice):

                break;
                /*
            case (CombatStates.nextTarget):
                if (curTarget <= 6)
                {
                    curTarget++;
                    Debug.Log("current target is: " + curTarget);
                    currState = CombatStates.playerChoice;
                    break;
                }
                else if (curTarget == 7)
                {
                    curTarget = 4;
                    Debug.Log("current target is: " + curTarget);
                    currState = CombatStates.playerChoice;
                    break;
                }
                break;

            case (CombatStates.prevTarget):
                if (curTarget >= 5)
                {
                    curTarget--;
                    Debug.Log("current target is: " + curTarget);
                    currState = CombatStates.playerChoice;
                    break;
                }
                else if (curTarget == 4)
                {
                    curTarget = 7;
                    Debug.Log("current target is: " + curTarget);
                    currState = CombatStates.playerChoice;
                    break;
                }
                break;
                */

            case (CombatStates.enemyGo):

                break;
                /*
            case (CombatStates.checkWin):
                if (CheckPlayerWin())
                {
                    currState = CombatStates.playerWin;
                }
                else if (CheckEnemyWin())
                {
                    currState = CombatStates.enemyWin;
                }
                else
                {
                    turnInc = 0;
                    currState = CombatStates.Turn;
                }

                break;
            case (CombatStates.enemyWin):
                Debug.Log("Enemy wins you suck");
                break;
            case (CombatStates.playerWin):
                Debug.Log("players win!");
                break;
                */
        }


    }

    #region old
    /*void OnGUI()
    {
        /*
        if(GUILayout.Button("Begin"))
        {
            if (currState == CombatStates.start)
            {
                turnInc = 0;
                currState = CombatStates.Turn;
            }
        }
        
        // if(GUILayout.Button("Action"))
        if (attackBtn.IsInvoking())
        {
            if(currState == CombatStates.playerChoice)
            {
                Debug.Log(curGoing + " has attacked enemy: " + curTarget + " for "
                          + CalcPlayerDamage(curGoing, FetchEnemyArmor()));
                switch(curTarget-4)
                {
                    case (1):
                        EnemyStats.Goon2HP = EnemyStats.Goon2HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                        Debug.Log("Goon2 has " + EnemyStats.Goon2HP + " Left ");
                        break;
                    case (2):
                        EnemyStats.Goon3HP = EnemyStats.Goon3HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                        Debug.Log("Goon3 has " + EnemyStats.Goon3HP + " Left ");
                        break;
                    case (3):
                        EnemyStats.Goon4HP = EnemyStats.Goon4HP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                        Debug.Log("Goon4 has " + EnemyStats.Goon4HP + " Left ");
                        break;
                    default:
                        EnemyStats.GoonHP = EnemyStats.GoonHP - CalcPlayerDamage(curGoing, FetchEnemyArmor());
                        Debug.Log("Goon has " + EnemyStats.GoonHP + " Left ");
                        break;
                }
                turnInc++;
                Debug.Log("turn inc to " + turnInc);
                currState = CombatStates.Turn;
            }
        }

        // if (GUILayout.Button("next"))
        if (nextBtn.IsInvoking())
        {
            if (currState == CombatStates.playerChoice)
            {
                currState = CombatStates.nextTarget;
            }
        }
        //if (GUILayout.Button("prev"))
        if (previousBtn.IsInvoking())
        {
            if (currState == CombatStates.playerChoice)
            {
                currState = CombatStates.prevTarget;
            }
        }
    }*/
#endregion
}