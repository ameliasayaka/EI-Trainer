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

        //if new day reset tasks
        if (isSameDay == false)
        {
            ResetTasks();

            Debug.Log("Reset!");
        }
    }

    public void CheckDate()
    {
        
        if (currentDate.Date == lastLoginDate.Date)
        {
            isSameDay = true;
            
        }
        else
        {
            isSameDay = false;
           
        }
    
        SaveLoadPlayerData.SaveData(dataHolder.player);
        
    }

    public void ResetTasks()
    {
        for (int i = 0; i < dataHolder.player.isDailyTaskComplete.Length; i++)
        {
            dataHolder.player.isDailyTaskComplete[i] = false;
        }
    }
}
