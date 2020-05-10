using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IntroSceneScript : MonoBehaviour /*IPointerClickHandler*/
{
    public CanvasGroup initialCanvasGroup;
    public CanvasGroup secondCanvasGroup;
    public CanvasGroup playerInputCanvasGroup;
    public CanvasGroup warningPanel;

    private UIFadeScript fadeScript;
    private GameObject gameManager;
    private Touch touch;

    private bool isNewPlayer;
    private bool isComplete;

    private string playerName;
    private string[] goals;

    public List<InputField> goalInputList;
    public InputField nameInput;

    private GameObject dataHolder;
    private DataHolder dataHolderScript;


    void Start()
    {
        //initialise fields
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        fadeScript = gameManager.GetComponent<UIFadeScript>();
        touch = new Touch();

        goals = new string[5];

        dataHolder = GameObject.FindGameObjectWithTag("DataHolder");
        dataHolderScript = dataHolder.GetComponent<DataHolder>();

        //If new player set bool
        if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.pd"))
        {
            isNewPlayer = false;
            Debug.Log(Application.persistentDataPath);
        }
        else
        {
            isNewPlayer = true;
            
        }

        isComplete = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (initialCanvasGroup.alpha == 0f && initialCanvasGroup.interactable == true)
        { fadeScript.Fade(initialCanvasGroup, true); }

        if (touch.phase == TouchPhase.Ended || Input.GetMouseButtonUp(0) == true)
        {
            //check if click registered
            //Debug.Log("Clicked");

            if (initialCanvasGroup.alpha < 1.0f && initialCanvasGroup.interactable == true)
            {
                initialCanvasGroup.alpha = 1.0f;
            }
            if (initialCanvasGroup.alpha == 1.0f)
            {
                Debug.Log("Clicked");
                fadeScript.Fade(initialCanvasGroup, false);
                initialCanvasGroup.interactable = false;
                
            }
        }
        //when initial canvas completes fade out fade in second canvas
        if (initialCanvasGroup.interactable == false && initialCanvasGroup.alpha == 0f && isComplete == false)
        {
            
            fadeScript.Fade(secondCanvasGroup, true);
            isComplete = true;
        }

        //when second canvas fades out fade in third canvas
        if (secondCanvasGroup.interactable == false && secondCanvasGroup.alpha == 0f && isComplete == true)
        {
            fadeScript.Fade(playerInputCanvasGroup, true);
        }
    }

    //Opens PlayerInputCanvas
    public void OpenPlayerInputCanvas()
    {
        Debug.Log(isNewPlayer);
        if (isNewPlayer == true)
        {
            Debug.Log("New Player");
            fadeScript.Fade(secondCanvasGroup, false);
            secondCanvasGroup.interactable = false;
            secondCanvasGroup.blocksRaycasts = false;
          
        }
        else
        {
            
            gameManager.GetComponent<SceneHandler>().OpenScene("Home");
        }
    }

    //Saves Player inputed data
    public void PlayerSetup()
    {
        bool isEmpty = false;
        playerName = nameInput.text;
        Debug.Log(playerName);
        for (int i = 0; i < goalInputList.Count; i++)
        {
            if (goalInputList[i].text != null)
            { goals[i] = goalInputList[i].text; }
            else
            {
                isEmpty = true;
                Debug.Log("Woops");
            }
        }

        if (playerName.Length > 1 && isEmpty == false)
        {

            dataHolderScript.player.playerGoals = goals;
            dataHolderScript.player.playerName = playerName;

            SaveLoadPlayerData.SaveData(dataHolderScript.player);
            gameManager.GetComponent<SceneHandler>().OpenScene("Home");
        }
        else
        {
            //Show Warning Panel
            warningPanel.alpha = 1f;
            warningPanel.interactable = true;
            warningPanel.blocksRaycasts = true;
        }

        
    }


    //requires users to click before moving on
    //public void OnPointerClick(PointerEventData pointerEventData)
    //{
    //    //check if click registered
    //     Debug.Log("Clicked");

    //    if(initialCanvasGroup.alpha == 1 && initialCanvasGroup.interactable == true)
    //    {
    //        fadeScript.Fade(false);
    //    }
    //}


}
