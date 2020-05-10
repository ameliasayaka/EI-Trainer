using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.Networking;

[XmlRoot("WordDatabase")]
public class Words
{
    [XmlArray("Words")]
    [XmlArrayItem("Word")]
    public Word[] wordsArray;

    public static Words Load(string fileName)
    {
        // string path = Application.streamingAssetsPath + "/" + fileName;
        // Debug.Log(path);

        // UnityWebRequest myWR = new UnityWebRequest("jar:file://" + path, "Get");
        //myWR.SendWebRequest();
        // XmlSerializer serializer = new XmlSerializer(typeof(Words));
        // using (MemoryStream stream = new MemoryStream(myWR.downloadHandler.data))
        // {
        //    return serializer.Deserialize(stream) as Words;

        // }

        Words deserialisedWords;
        XmlSerializer deserializer = new XmlSerializer(typeof(Words));
        TextAsset xml = Resources.Load(fileName) as TextAsset;

        using (MemoryStream stream = new MemoryStream(xml.bytes))
        {
            deserialisedWords = deserializer.Deserialize(stream) as Words;
        }

        return deserialisedWords;
    }


}
public class Word
{
    [XmlAttribute("category")]
    public string category;

    public string name;

    public string definition;


}
