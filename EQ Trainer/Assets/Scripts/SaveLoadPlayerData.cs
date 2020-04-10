using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveLoadPlayerData
{

    //public static PlayerData playerData;
    //public GameObject DataHolder;

    public static void SaveData(PlayerData player)
    {
        BinaryFormatter bFormatter = new BinaryFormatter();
        FileStream file = System.IO.File.Create(Application.persistentDataPath + "/playerData.pd");
        

        
        bFormatter.Serialize(file, player);
        file.Close();


       // Debug.Log(player.playerName);
        
    }
    public static PlayerData LoadData(PlayerData playerData)
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.pd"))
        {
            //playerData = new PlayerData();
            BinaryFormatter bFormatter = new BinaryFormatter();
            FileStream file = System.IO.File.Open(Application.persistentDataPath + "/playerData.pd", FileMode.Open);
            playerData = (PlayerData)bFormatter.Deserialize(file);
            file.Close();

            return playerData;
        }
        return null;
    }
}
