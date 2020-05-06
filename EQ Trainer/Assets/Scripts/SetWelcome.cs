using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWelcome : MonoBehaviour
{
    //text to change
    public Text welcomeText;

    private string baseWelcomeMessage = "Welcome";
    //access player details
    private PlayerData playerData;
    private string playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        
        welcomeText.text = baseWelcomeMessage;

        if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.pd"))
        {
            playerData = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>().player;
            playerName = playerData.playerName;

            welcomeText.text += (" back, " + playerName);
        }

    }

    //on changing player name updates text
public void ChangeName()
    {
        playerName = playerData.playerName;

        welcomeText.text += playerName;
    }
}
