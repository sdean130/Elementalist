using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyStats
{
    private static int goonS, goon2S, goon3S, goon4S, bossS;// stat
    private static int goonHP, goon2HP, goon3HP, goon4HP, bossHP;// hp
    private static float goonA, goon2A, goon3A, goon4A, bossA;// armor

    #region goon
    public static int GoonHP
    {
        get { return goonHP; }
        set { goonHP = value; }
    }
    public static int GoonS
    {
        get { return goonS; }
        set { goonS = value; }
    }
    public static float GoonA
    {
        get { return goonA; }
        set { goonA = value; }
    }
    #endregion
    #region goon2
    public static int Goon2HP
    {
        get { return goon2HP; }
        set { goon2HP = value; }
    }
    public static int Goon2S
    {
        get { return goon2S; }
        set { goon2S = value; }
    }
    public static float Goon2A
    {
        get { return goon2A; }
        set { goon2A = value; }
    }
    #endregion
    #region goon3
    public static int Goon3HP
    {
        get { return goon3HP; }
        set { goon3HP = value; }
    }
    public static int Goon3S
    {
        get { return goon3S; }
        set { goon3S = value; }
    }
    public static float Goon3A
    {
        get { return goon3A; }
        set { goon3A = value; }
    }
    #endregion
    #region goon4
    public static int Goon4HP
    {
        get { return goon4HP; }
        set { goon4HP = value; }
    }
    public static int Goon4S
    {
        get { return goon4S; }
        set { goon4S = value; }
    }
    public static float Goon4A
    {
        get { return goon4A; }
        set { goon4A = value; }
    }
    #endregion
    #region boss
    public static int BossHp
    {
        get { return bossHP; }
        set { bossHP = value; }
    }
    public static int BossS
    {
        get { return bossS; }
        set { bossS = value; }
    }
    public static float BossA
    {
        get { return bossA; }
        set { bossA = value; }
    }
    #endregion
}
