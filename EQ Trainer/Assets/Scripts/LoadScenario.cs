using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Testing")]
public class Scenarios
{
    [XmlArray("Scenarios")]
    [XmlArrayItem("Scenario")]
    public Scenario[] scenariosArray;

    public static Scenarios Load(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Scenarios));
        Scenarios deserialisedScenarios;
        XmlSerializer deserializer = new XmlSerializer(typeof(Scenarios));
        TextAsset xml = Resources.Load(fileName) as TextAsset;

        using (MemoryStream stream = new MemoryStream(xml.bytes))
        {
            deserialisedScenarios = deserializer.Deserialize(stream) as Scenarios;
        }

        return deserialisedScenarios;
    }

}
public class Scenario
{
    [XmlAttribute("category")]
    public string category;

    public string text;

    [XmlArray("Options")]
    [XmlArrayItem("option")]
    public Option[] Options;


}


public class Option
{
   [XmlElement("optionText")]
    public string optionText;
    
    public int score;
}
