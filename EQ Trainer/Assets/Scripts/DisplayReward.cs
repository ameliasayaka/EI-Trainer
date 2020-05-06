using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//to be attached to reward object
public class DisplayReward : MonoBehaviour
{
    private Text rewardText;
    private GameObject dataHolder;
    private DataHolder playerData;

    // Start is called before the first frame update
    void Start()
    {
        rewardText = gameObject.GetComponent<Text>();
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder");
        playerData = dataHolder.GetComponent<DataHolder>();

        SetRewardText();
    }

    //Set Reward Text
    public void SetRewardText()
    {
        rewardText.text = "Reward Points: " + playerData.player.RewardPoints; 
    }
}
