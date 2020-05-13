using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

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


        if (File.Exists(Application.persistentDataPath + "/playerData.pd"))
        {
            Debug.Log(Application.persistentDataPath);

            player = SaveLoadPlayerData.LoadData(player);

          //  Debug.Log(player.playerName);
           // Debug.Log(player.playerGoals[0]);
        }
    }

    public void ResetPlayerData()
    {
        Debug.Log("Clicked!");
        //string path = Application.persistentDataPath + "/playerData.pd";
        //Debug.Log(File.Exists(path));
        //File.Delete(path);

        //Debug.Log(File.Exists(path));

        ////Quit application
        ////gameObject.GetComponent<SceneHandler>().QuitGame();
    }

    public void SaveData()
    {
        SaveLoadPlayerData.SaveData(player);
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
