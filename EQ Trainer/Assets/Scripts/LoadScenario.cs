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

    public static Scenarios Load(string path)
    {
        var serializer = new XmlSerializer(typeof(Scenarios));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as Scenarios;
        }
    }

}
public class Scenario
{
    [XmlAttribute("category")]
    public string category;

    public string text;

    [XmlArray("Options")]
    [XmlArrayItem("option")]
    public List<Option> Options = new List<Option>();


}
public class Option
{
    public string text;
    public int score;
}

