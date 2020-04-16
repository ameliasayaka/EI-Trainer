using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordPicker : MonoBehaviour
{
    private string filePath = "Assets/Data/WordDatabase.xml";
    private int currentWordIndex;
    private Word[] wordsArray;
    private Word[] wordsArrayRand;
    private Words words;
    public int gameLength = 10;

    private GameObject gameManager;
    private RewardScript rewardScript;

    //Canvas Items
    public Text wordText;
    public GameObject wordCanvas;
    public GameObject buttonCanvas;
    public GameObject introOutroPanel;
    public GameObject reviewPanel;
    public Text reviewPanelText;

    private CanvasGroup buttonCanvasGroup;
    private CanvasGroup reviewCanvasGroup;

    



    // Start is called before the first frame update
    void Start()
    {
        //initialise fields
        currentWordIndex = 0;
        wordText = wordText.GetComponent<Text>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        rewardScript = gameManager.GetComponent<RewardScript>();
        buttonCanvasGroup = buttonCanvas.GetComponent<CanvasGroup>();
        reviewCanvasGroup = reviewPanel.GetComponent<CanvasGroup>();

        //load word database xml & set array
        words = Words.Load(filePath);

        // Debug.Log(words.wordsArray.Length);
       
        wordsArray = words.wordsArray; 
        wordsArrayRand = new Word[gameLength];

        //pick random words
        ShuffleArray(wordsArray);


        //Debug.Log(wordsArrayRand[0].name);

        //Set text to current word   
        wordText.text = wordsArrayRand[currentWordIndex].name;

        //Set Review Text
        SetReviewText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckWord(string category)
    {
        //deactivate buttons

        if (Equals(wordsArrayRand[currentWordIndex].category,category))
        {
            // flash green or something

            //add reward points
            rewardScript.Score += 1;

        }

        // set text to definition
        //wordText.text = wordsArrayRand[currentWordIndex].definition;

        // buttonCanvasGroup.interactable = false;
        
        //  continue button

    }

    public void LoadNextArray()
    {
        if (currentWordIndex + 1 < gameLength) //avoid range out of bounds
        {
            currentWordIndex++;

            wordText.text = wordsArrayRand[currentWordIndex].name;
        }
        else //once end of questions show end screen
        {
            //finished screen
            CallFade(reviewCanvasGroup);
            buttonCanvasGroup.interactable = false;
            buttonCanvasGroup.blocksRaycasts = false;
            rewardScript.AddReward();
        }
    }

    //Sets wordsArrayRand to have random words and their definitions
    public void ShuffleArray(Word[] wordArray)
    {
        System.Random rand = new System.Random();
        int randElement;

        for (int i = 0; i < gameLength; i++)
        {
            randElement = rand.Next(0, wordArray.Length);

            while (wordArray[randElement] == null) // check element is not null
            {
                randElement = rand.Next(0, wordArray.Length);
            }
                wordsArrayRand[i] = wordArray[randElement];
                wordsArray[randElement] = null; //set to null to prevent duplicates         
        }
    }

    //calls fade script
    public void CallFade(CanvasGroup canvasGroup)
    {
        bool fadeIn;

        //chech whether to fade in or out
        if(canvasGroup.interactable == true)
        {
            fadeIn = false;
        }
        else
        {
            fadeIn = true;
        }
        gameManager.GetComponent<UIFadeScript>().Fade(canvasGroup,fadeIn);

        canvasGroup.interactable = fadeIn;
        canvasGroup.blocksRaycasts = fadeIn;
    }

    private void SetReviewText()
    {
        reviewPanelText.text = "";
        for (int i=0; i < gameLength; i++)
        {
            reviewPanelText.text += wordsArrayRand[i].name + "\n";
            reviewPanelText.text += wordsArrayRand[i].definition + "\n";
        }
    }
}
