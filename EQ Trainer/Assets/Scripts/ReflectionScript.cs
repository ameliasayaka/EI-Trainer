using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReflectionScript : MonoBehaviour
{
    public string PlayerEmotion { get; set; }
    public int EmotionIntensity { get; set; }

    public Scrollbar scrollbarFirst;
    public InputField emotionInput;

    public Text reflectionMessage;
    public Text welcomeText;

    public GameObject initialPanel;
    private CanvasGroup initialCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        EmotionIntensity = 0;
        welcomeText.text = "Welcome " + GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>().player.playerName;

        //fade in initial canvas
        initialCanvasGroup = initialPanel.GetComponent<CanvasGroup>();
        initialCanvasGroup.GetComponent<UIFadeScript>().CallFadeForAttachedCanvas(true);
    }

    public void SetEmotionandText()
    {
        PlayerEmotion = emotionInput.text;

        reflectionMessage.text = "You were feeling " + PlayerEmotion + " with an intensity of " + EmotionIntensity;
    }
    public void SetIntensity()
    {
        EmotionIntensity = Mathf.FloorToInt(scrollbarFirst.value * 10f);
    }
  
}
