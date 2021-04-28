using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("characterOptions")]

public class characterOptions 
{

    [XmlArray("characters")]
    [XmlArrayItem("character")]

    public List<character> characters = new List<character>();

    public static characterOptions Load(string path)
    {
        TextAsset xmlData = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(characterOptions));
        StringReader reader = new StringReader(xmlData.text);

        characterOptions characters = serializer.Deserialize(reader) as characterOptions;

        reader.Close();

        return characters;
    }
}
