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

    public static Faces Load(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Faces));
        Faces deserialisedFaces;
        XmlSerializer deserializer = new XmlSerializer(typeof(Faces));
        TextAsset xml = Resources.Load(fileName) as TextAsset;

        using (MemoryStream stream = new MemoryStream(xml.bytes))
        {
            deserialisedFaces = deserializer.Deserialize(stream) as Faces;
        }

        return deserialisedFaces;
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



