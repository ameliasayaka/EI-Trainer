using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{
    public int Score { get; set; }
    void AddScore()
    {
        GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>().player.RewardPoints += Score;
    }
}
