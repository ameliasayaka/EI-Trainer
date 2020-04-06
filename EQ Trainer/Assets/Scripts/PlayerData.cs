using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    static public string PlayerName { get; set; }
    static List<PlayerScore> playerScoreList;
    static List<string> playerGoals;
    static private int rewardPoints;
    static private float volume;


    //Properties
    static public int RewardPoints
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

    static public float Volume
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
