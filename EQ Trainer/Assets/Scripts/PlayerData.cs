using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerData /*: MonoBehaviour*/
{
    public string playerName;
    public List<PlayerScore> playerScoreList;
    public string[] playerGoals;
    public int rewardPoints;
    public float volume;
    public DateTime loginDate;

    //Constructors
    public PlayerData()
    {
        playerName = null;
        playerGoals = new string[5];
        rewardPoints = 0;
        playerScoreList = new List<PlayerScore>();
        volume = 1f;
        loginDate = DateTime.Now;
    }

    //Properties
    public int RewardPoints
    {
        get { return rewardPoints; }
        set 
        {
            if (value >= 0)
            {
                rewardPoints = value;
            }
        }
    }

     public float Volume
    {
        get { return volume; }
        set
        {
            if (value >= 0.0 && value <= 1.0)
            {
                volume = value;
            }
        }
    }

}

[System.Serializable]
public class PlayerScore
    {
        int score;
        string date;
    }
