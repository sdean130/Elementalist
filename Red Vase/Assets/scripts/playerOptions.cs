using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("playerOptions")]

public class playerOptions 
{

    [XmlArray("players")]
    [XmlArrayItem("player")]

    public List<player> players = new List<player>();

    public static playerOptions Load(string path)
    {
        TextAsset xmlData = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(playerOptions));
        StringReader reader = new StringReader(xmlData.text);

        playerOptions players = serializer.Deserialize(reader) as playerOptions;

        reader.Close();

        return players;
    }
}
