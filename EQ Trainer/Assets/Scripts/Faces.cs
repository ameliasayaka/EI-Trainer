using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("FaceExercise")]
public class Faces
{
    [XmlArray("Faces")]
    [XmlArrayItem("Face")]
    public Face[] facesArray;

    public static Faces Load(string path)
    {
        var serializer = new XmlSerializer(typeof(Faces));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as Faces;
        }
    }

}

public class Face
{
    [XmlElement("emotion")]
    public string emotion;
    [XmlElement("Explanation")]
    public string explanation;

    [XmlArray("ids")]
    [XmlArrayItem("id")]
    public string[] faceIds;
}



