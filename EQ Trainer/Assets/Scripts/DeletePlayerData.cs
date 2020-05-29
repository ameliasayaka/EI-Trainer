using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DeletePlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    public void DeleteData()
    {
        string path = Application.persistentDataPath + "/playerData.pd";
        Debug.Log(File.Exists(path));

        if(File.Exists(path))
        {
            File.Delete(path);

        }
    }
}
