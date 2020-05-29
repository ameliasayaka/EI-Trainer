using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadPlayerData
{

    public static void SaveData(PlayerData player)
    {
        BinaryFormatter bFormatter = new BinaryFormatter();
        FileStream file = System.IO.File.Create(Application.persistentDataPath + "/playerData.pd");
        

        
        bFormatter.Serialize(file, player);
        file.Close();


       // Debug.Log(player.playerName);
        
    }
    public static PlayerData LoadData(PlayerData player)
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.pd"))
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            FileStream file = System.IO.File.Open(Application.persistentDataPath + "/playerData.pd", FileMode.Open);
            player = (PlayerData)bFormatter.Deserialize(file);
            file.Close();

            return player;
        }
        return null;
    }


}
