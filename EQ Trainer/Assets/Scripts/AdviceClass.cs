using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("Testing")]
public class AdviceClass
{
    [XmlArray("Advice")]
    [XmlArrayItem("Tip")]
    public string[] tipArray;

    public static AdviceClass Load(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(AdviceClass));
        AdviceClass deserialisedAdvice;
        XmlSerializer deserializer = new XmlSerializer(typeof(AdviceClass));
        TextAsset xml = Resources.Load(fileName) as TextAsset;

        using (MemoryStream stream = new MemoryStream(xml.bytes))
        {
            deserialisedAdvice = deserializer.Deserialize(stream) as AdviceClass;
        }

        return deserialisedAdvice;
    }

}
