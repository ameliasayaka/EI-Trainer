using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float time = 120f;
    private int minutes;
    private int seconds;
    public bool isTimerRunning;
   

    // Start is called before the first frame update
    void Start()
    {
        isTimerRunning = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isTimerRunning == true)
        {
            if (time > 0)
            {
                time -= Time.fixedDeltaTime;
            }
            else
            {
                time = 0f;
                isTimerRunning = false;
            }
        }
        
    }

    public int Minutes
    {
        get { return Mathf.FloorToInt(time / 60f); }
    }

    public int Seconds
    {
        //returns remaining seconds that doesnt make up a minute
        get { return Mathf.FloorToInt(time % 60f); }
    }
}
