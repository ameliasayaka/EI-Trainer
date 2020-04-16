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


}
