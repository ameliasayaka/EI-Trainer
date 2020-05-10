using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SetAdvice : MonoBehaviour
{
    private string fileName = "testScenarioData";
    private string[] tipArray;
    private AdviceClass advice;
    private int tipIndex;
    private Text tipText;
    
    // Start is called before the first frame update
    void Start()
    {
        tipIndex = 0;
        tipText = gameObject.GetComponent<Text>();
        LoadAdvice();
        tipIndex = RandomIndex();
        SetAdviceText();
    }

    // Update is called once per frame

    private void LoadAdvice()
    {
        advice = AdviceClass.Load(fileName);
        tipArray = advice.tipArray;
    }
    private int RandomIndex()
    {
        System.Random rand = new System.Random();
        int index;

        index = rand.Next(0, tipArray.Length);

        return index;
    }
    private void SetAdviceText()
    {
        tipText.text = tipArray[tipIndex];
    }
}
