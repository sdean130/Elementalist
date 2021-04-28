using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class enemy 
{
    string enemyName;
    [XmlAttribute("name")]
    public string EnemyName
    {
        get { return enemyName; }
        set { enemyName = value; }
    }

    int id;
    [XmlElement("ID")]
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    int health;
    [XmlElement("health")]
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    float armor;
    [XmlElement("armor")]
    public float Armor
    {
        get { return armor; }
        set { armor = value; }
    }

    int stat;
    [XmlElement("stat")]
    public int Stat
    {
        get { return stat; }
        set { stat = value; }
    }
}
