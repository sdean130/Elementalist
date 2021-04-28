using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("enemyOptions")]

public class enemyOptions 
{

    [XmlArray("enemies")]
    [XmlArrayItem("enemy")]

    public List<enemy> enemies = new List<enemy>();

    public static enemyOptions Load(string path)
    {
        TextAsset xmlData = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(enemyOptions));
        StringReader reader = new StringReader(xmlData.text);

        enemyOptions enemies = serializer.Deserialize(reader) as enemyOptions;

        reader.Close();

        return enemies;
    }
}
