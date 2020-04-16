using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

public class XMLController : MonoBehaviour
{
    string fileName = "Assets/Data/testScenarioData";

    void Start()
    {

    }

    public static void LoadXML(string path)
    {
        Scenarios scenarios = new Scenarios();

        XmlSerializer serializer = new XmlSerializer(typeof(Scenarios));
        StreamReader reader = new StreamReader(path);
        Scenarios deserialized = (Scenarios)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        //return deserialized;

        
    }
}

