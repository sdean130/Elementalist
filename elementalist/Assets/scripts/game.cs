using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class game : MonoBehaviour
{
    void Start()
    {
        // writing values to static script
        characterOptions CO = characterOptions.Load("characterData");
        enemyOptions EO = enemyOptions.Load("enemyData");

        foreach (enemy Enemy in EO.enemies)
        {
            if (Enemy.ID == 1)
            {
                EnemyStats.GoonHP = Enemy.Health;
                EnemyStats.Goon2HP = Enemy.Health;
                EnemyStats.Goon3HP = Enemy.Health;
                EnemyStats.Goon4HP = Enemy.Health;
                EnemyStats.GoonS = Enemy.Stat;
                EnemyStats.Goon2S = Enemy.Stat;
                EnemyStats.Goon3S = Enemy.Stat;
                EnemyStats.Goon4S = Enemy.Stat;
                EnemyStats.GoonA = Enemy.Armor;
                EnemyStats.Goon2A = Enemy.Armor;
                EnemyStats.Goon3A = Enemy.Armor;
                EnemyStats.Goon4A = Enemy.Armor;
            }
            else if (Enemy.ID == 2)
            {
                EnemyStats.BossHp = Enemy.Health;
                EnemyStats.BossS = Enemy.Stat;
                EnemyStats.BossA = Enemy.Armor;
            }
        }

        if (teamStats.SetUp)
        {
            foreach (character Character in CO.characters)
            {
                if (Character.ID == 1)
                {
                    teamStats.PlayerHealth = Character.Health;
                    teamStats.PlayerStam = Character.Resource;
                    teamStats.PlayerHRecov = Character.Hrecovery;
                    teamStats.PlayerSRecov = Character.Rrecovery;
                    teamStats.PlayerA = Character.Armor;
                    teamStats.PlayerI = Character.Initiative;
                    teamStats.PlayerPStat = Character.Stat;
                }
                else if (Character.ID == 2)
                {
                    teamStats.MageHealth = Character.Health;
                    teamStats.MageMana = Character.Resource;
                    teamStats.MageHRecov = Character.Hrecovery;
                    teamStats.MageMRecov = Character.Rrecovery;
                    teamStats.MageA = Character.Armor;
                    teamStats.MageI = Character.Initiative;
                    teamStats.MagePStat = Character.Stat;
                }
                else if (Character.ID == 3)
                {
                    teamStats.TankHealth = Character.Health;
                    teamStats.TankStam = Character.Resource;
                    teamStats.TankHRecov = Character.Hrecovery;
                    teamStats.TankSRecov = Character.Rrecovery;
                    teamStats.TankA = Character.Armor;
                    teamStats.TankI = Character.Initiative;
                    teamStats.TankPStat = Character.Stat;
                }
                else if (Character.ID == 4)
                {
                    teamStats.SupportHealth = Character.Health;
                    teamStats.SupportMana = Character.Resource;
                    teamStats.SupportHRecov = Character.Hrecovery;
                    teamStats.SupportMRecov = Character.Rrecovery;
                    teamStats.SupportA = Character.Armor;
                    teamStats.SupportI = Character.Initiative;
                    teamStats.SupportPStat = Character.Stat;
                }

            }
            teamStats.SetUp = false;
        }

    }
}