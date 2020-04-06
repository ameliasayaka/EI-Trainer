using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.Windows;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadPlayerData
{

    private static PlayerData playerData;

    public static void SaveData()
    {
        BinaryFormatter bFormatter = new BinaryFormatter();
        FileStream file = System.IO.File.Create(Application.persistentDataPath + "/playerData.pd");
        bFormatter.Serialize(file, playerData);
        file.Close();
    }
    public static void LoadData()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            FileStream file = System.IO.File.Open(Application.persistentDataPath + "/playerData.pd", FileMode.Open);
            SaveLoadPlayerData.playerData = (PlayerData)bFormatter.Deserialize(file);
            file.Close();
        }
    }
}
