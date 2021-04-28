using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;


public class player
{
    string charName;
    [XmlAttribute("name")]
    public string CharName
    {
        get { return charName; }
        set { charName = value; }
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

    int dps;
    [XmlElement("dps")]
    public int Dps
    {
        get { return dps; }
        set { dps = value; }
    }

    float moveSpeed;
    [XmlElement("moveSpeed")]
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    float attSpeed;
    [XmlElement("attSpeed")]
    public float AttSpeed
    {
        get { return attSpeed; }
        set { attSpeed = value; }
    }
}
