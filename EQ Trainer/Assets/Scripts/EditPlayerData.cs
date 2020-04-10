using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditPlayerData : MonoBehaviour
{
    private GameObject dataHolder;
    //private SaveLoadPlayerData saveLoadScript;
    public List<InputField> goalInputList;
    public InputField nameInput;

    private string playerName;
    private string[] goals;

    private bool containsNull;

    DataHolder dataHolderScript;

    // Start is called before the first frame update
    void Start()
    {
        //initialise
        containsNull = false;
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder");
        dataHolderScript = dataHolder.GetComponent<DataHolder>();

        goals = new string[5];


        //set input field text to existing values
        for (int i = 0; i < goalInputList.Count; i++)
        {
            goalInputList[i].text = dataHolderScript.player.playerGoals[i];
        }
        nameInput.text = dataHolderScript.player.playerName;
    }

    //Set New Name and Goals
    public void SavePlayerChanges()
    {

        playerName = nameInput.text;

        for (int i = 0; i < goalInputList.Count; i++)
        {
            if (goalInputList[i].text != null)
            { goals[i] = goalInputList[i].text; }
            else
            {
                containsNull = true;
            }
        }

        if (playerName != null && !containsNull)
        {
            dataHolderScript.player.playerName = playerName;
            for (int i = 0; i < goalInputList.Count; i++)
            {
                dataHolderScript.player.playerGoals[i] = goals[i];
            }
            SaveLoadPlayerData.SaveData(dataHolderScript.player);
        }
        else
        {
            //write something to player telling them to input something
        }


    }
}
