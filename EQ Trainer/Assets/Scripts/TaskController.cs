using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    private Toggle toggle;
    private PlayerData player;

    public int taskIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>().player;
       toggle = gameObject.GetComponent<Toggle>();
       

       if (player.isDailyTaskComplete[taskIndex] == false)
        {
            toggle.interactable = true;
        }
        else
        {
            toggle.isOn = true;
            toggle.interactable = false;
        }
    }


    //locks toggle for rest of day
    public void LockToggle()
    {
        player.isDailyTaskComplete[taskIndex] = true;
        toggle.interactable = false;

        SaveLoadPlayerData.SaveData(player);
    }
}
