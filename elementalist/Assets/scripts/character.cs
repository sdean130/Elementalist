using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;


public class character
{
    [XmlAttribute("name")]
    public string CharName { get; set; }

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

    float hrecovery;
    [XmlElement("hrecovery")]
    public float Hrecovery
    {
        get { return hrecovery; }
        set { hrecovery = value; }
    }

    int resource;
    [XmlElement("resource")]
    public int Resource
    {
        get { return resource; }
        set { resource = value; }
    }
    float rrecovery;
    [XmlElement("rrecovery")]
    public float Rrecovery
    {
        get { return rrecovery; }
        set { rrecovery = value; }
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

    float initiative;
    [XmlElement("initiative")]
    public float Initiative
    {
        get { return initiative; }
        set { initiative = value; }
    }


}
