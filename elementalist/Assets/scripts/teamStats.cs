using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class teamStats
{
    // static script whos job is to hold onto data
    private static bool setUp = true;
    private static int playerHealth, mageHealth, tankHealth, supportHealth;
    private static int playerStam, mageMana, tankStam, supportMana;
    private static float playerHRecov, mageHRecov, tankHRecov, supportHRecov;
    private static float playerSRecov, mageMRecov, tankSRecov, supportMRecov;
    private static int playerPStat, magePStat, tankPStat, supportPStat;// primary stat
    private static float playerI, mageI, tankI, supportI;// initiative
    private static float playerA, mageA, tankA, supportA;// armor

    public static bool SetUp
    {
        get { return setUp; }
        set { setUp = value; }
    }

    #region PlayerStats
    public static int PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    public static int PlayerStam
    {
        get { return playerStam; }
        set { playerStam = value; }
    }

    public static float PlayerHRecov
    {
        get { return playerHRecov; }
        set { playerHRecov = value; }
    }

    public static float PlayerSRecov
    {
        get { return playerSRecov; }
        set { playerSRecov = value; }
    }

    public static int PlayerPStat
    {
        get { return playerPStat; }
        set { playerPStat = value; }
    }

    public static float PlayerI
    {
        get { return playerI; }
        set { playerI = value; }
    }

    public static float PlayerA
    {
        get { return playerA; }
        set { playerA = value; }
    }

    #endregion

    #region MageStats
    public static int MageHealth
    {
        get { return mageHealth; }
        set { mageHealth = value; }
    }
    public static int MageMana
    {
        get { return mageMana; }
        set { mageMana = value; }
    }
    public static float MageHRecov
    {
        get { return mageHRecov; }
        set { mageHRecov = value; }
    }

    public static float MageMRecov
    {
        get { return mageMRecov; }
        set { mageMRecov = value; }
    }

    public static int MagePStat
    {
        get { return magePStat; }
        set { magePStat = value; }
    }

    public static float MageI
    {
        get { return mageI; }
        set { mageI = value; }
    }

    public static float MageA
    {
        get { return mageA; }
        set { mageA = value; }
    }
    #endregion

    #region TankStats
    public static int TankHealth
    {
        get { return tankHealth; }
        set { tankHealth = value; }
    }
    public static int TankStam
    {
        get { return tankStam; }
        set { tankStam = value; }
    }
    public static float TankHRecov
    {
        get { return tankHRecov; }
        set { tankHRecov = value; }
    }

    public static float TankSRecov
    {
        get { return tankSRecov; }
        set { tankSRecov = value; }
    }

    public static int TankPStat
    {
        get { return tankPStat; }
        set { tankPStat = value; }
    }

    public static float TankI
    {
        get { return tankI; }
        set { tankI = value; }
    }

    public static float TankA
    {
        get { return tankA; }
        set { tankA = value; }
    }
    #endregion

    #region SupportStats
    public static int SupportHealth
    {
        get { return supportHealth; }
        set { supportHealth = value; }
    }
    public static int SupportMana
    {
        get { return supportMana; }
        set { supportMana = value; }
    }
    public static float SupportHRecov
    {
        get { return supportHRecov; }
        set { supportHRecov = value; }
    }

    public static float SupportMRecov
    {
        get { return supportMRecov; }
        set { supportMRecov = value; }
    }

    public static int SupportPStat
    {
        get { return supportPStat; }
        set { supportPStat = value; }
    }

    public static float SupportI
    {
        get { return supportI; }
        set { supportI = value; }
    }

    public static float SupportA
    {
        get { return supportA; }
        set { supportA = value; }
    }
    #endregion
}