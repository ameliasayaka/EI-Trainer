using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditPlayerData : MonoBehaviour
{
    private GameObject dataHolder;
    public List<InputField> goalInputList;
    public InputField nameInput;
    public CanvasGroup warningPanel;
    public CanvasGroup playerSettingsPanel;
    public CanvasGroup optionsPanel;

    private string playerName;
    private string[] goals;

    private bool containsNull;

    private DataHolder dataHolderScript;

    // Start is called before the first frame update
    void Start()
    {
        //initialise
        containsNull = false;
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder");
        dataHolderScript = dataHolder.GetComponent<DataHolder>();

        goals = new string[5];


        //set input field text to existing values
        if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.pd"))
        {
            for (int i = 0; i < goalInputList.Count; i++)
            {
                goalInputList[i].text = dataHolderScript.player.playerGoals[i];
            }
            nameInput.text = dataHolderScript.player.playerName;
        }
    }

    //Set New Name and Goals
    public void SavePlayerChanges()
    {

        playerName = nameInput.text;

        for (int i = 0; i < goalInputList.Count; i++)
        {
            if (goalInputList[i].text.Length > 1)
            { goals[i] = goalInputList[i].text; }
            else
            {
                containsNull = true;
            }
        }

        if (playerName.Length > 1 && !containsNull)
        {
            dataHolderScript.player.playerName = playerName;
            for (int i = 0; i < goalInputList.Count; i++)
            {
                dataHolderScript.player.playerGoals[i] = goals[i];
            }
            SaveLoadPlayerData.SaveData(dataHolderScript.player);
            optionsPanel.interactable = true;
            playerSettingsPanel.interactable = false;
            playerSettingsPanel.GetComponent<UIScrollScript>().Scroll();
        }
        else
        {
            //Show Warning Panel
            warningPanel.alpha = 1f;
            warningPanel.interactable = true;
            warningPanel.blocksRaycasts = true;
        }


    }
}
