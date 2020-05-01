using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatchScript : MonoBehaviour
{
    private GameObject gameManager;
    public Text timerText;
    private TimerScript timerScript;
    public Button continueButton;
    private bool isButtonShown;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        timerScript = gameManager.GetComponent<TimerScript>();
        timerText.text = string.Format("{0:00}:{1:00}", timerScript.Minutes, timerScript.Seconds);
        isButtonShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerScript.isTimerRunning == true)
        { timerText.text = string.Format("{0:00}:{1:00}", timerScript.Minutes, timerScript.Seconds); }

        if (timerScript.time == 0f && isButtonShown == false)
        {
            //complete sound
            gameManager.GetComponent<PlaySoundScript>().PlaySound(true);
            //show review panel
            gameManager.GetComponent<UIFadeScript>().Fade(continueButton.GetComponent<CanvasGroup>(), true); //fade in button

            // continueButton.interactable = true;
            timerText.text = "00:00";
            isButtonShown = true;

        }
    }

    //public void StartTimer()
    //{
    //    timerScript.isTimerRunning = true;
    //}
    public void PausePlayTimer()
    {
        bool isPaused = !timerScript.isTimerRunning;
        timerScript.isTimerRunning = isPaused;
    }
}
