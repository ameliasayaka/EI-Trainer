using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{
    public int score;

    void AddScore()
    {
        PlayerData.RewardPoints += score;
    }
}
