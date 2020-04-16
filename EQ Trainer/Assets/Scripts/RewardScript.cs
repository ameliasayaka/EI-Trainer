using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{
    public int Score { get; set; }

   public void AddReward()
    {
        if (Score >= 0)
        { GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>().player.RewardPoints += Score; }
        
    }
    //overload
    public void AddReward(int score)
    {
        if (score >= 0)
        { GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>().player.RewardPoints += score; }
    }


}
