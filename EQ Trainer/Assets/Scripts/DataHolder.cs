using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public PlayerData player;
    private SaveLoadPlayerData playerDataScript;
    
    private void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("DataHolder");

        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        
        DontDestroyOnLoad(this.gameObject);

        player = new PlayerData();


        if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.pd"))
        {
            Debug.Log(Application.persistentDataPath);

            player = SaveLoadPlayerData.LoadData(player);

            Debug.Log(player.playerName);
            Debug.Log(player.playerGoals[0]);
        }
    }

    //private void Start()
    //{
    //    if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.pd"))
    //    {
    //        Debug.Log(Application.persistentDataPath);

    //        player = SaveLoadPlayerData.LoadData(player);

    //        Debug.Log(playerDataScript.playerData.playerName);

    //    }
    //}
}
