using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private DateTime currentDate;
    private DateTime lastLoginDate;

    private bool isSameDay;

    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        currentDate = DateTime.Now;
        lastLoginDate = dataHolder.player.loginDate;

        CheckDate();
    }

    public void CheckDate()
    {
        if (currentDate.Date == lastLoginDate.Date)
        {
            isSameDay = true;
            ResetTasks();
        }
        else
        {
            isSameDay = false;
        }

        SaveLoadPlayerData.SaveData(dataHolder.player);
    }

    public void ResetTasks()
    {
        //reset checkbox (set interactable)
    }
}
