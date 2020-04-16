using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("WordDatabase")]
public class Words
{
    [XmlArray("Words")]
    [XmlArrayItem("Word")]
    public Word[] wordsArray;

    public static Words Load(string path)
    {
        var serializer = new XmlSerializer(typeof(Words));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as Words;
        }
    }

}
public class Word
{
    [XmlAttribute("category")]
    public string category;

    public string name;

    public string definition;


}
