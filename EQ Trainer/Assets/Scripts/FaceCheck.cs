using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceCheck : MonoBehaviour
{

    private string[] answerIds;
    private string[] correctIds;
    private bool isCorrect;
    private int currentQuestion;

    private Faces faces;
    private Face[] facesArray;
    private Face[] faceArrayRand;

    //Face features GameObject spriteRenderers
    public GameObject brows;
    public GameObject eyes;
    public GameObject nose;
    public GameObject mouth;

    //prompt text
    public Text prompt;
    

    //put renderers into array
    private GameObject[] faceGameObjects;
    private SpriteRenderer[] spriteRenderers;
    private Sprite[] sprites;

    //answer panel
    private GameObject answerPanel;
    private FaceAnswerPanel answerPanelScript;

    //game manager
    private GameObject gameManager;
    private SceneHandler sceneHandleScript;
    private RewardScript rewardScript;

    // Start is called before the first frame update
    void Start()
    {
        //Initialise fields
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        sceneHandleScript = gameManager.GetComponent<SceneHandler>();
        rewardScript = gameManager.GetComponent<RewardScript>();


        currentQuestion = 0;
        isCorrect = true;
        answerIds = new string[4];
        correctIds = new string[4];


        faceGameObjects = new GameObject[] { brows, eyes, nose, mouth };
        spriteRenderers = new SpriteRenderer[4];

        for(int i = 0; i < faceGameObjects.Length; i++)
        {
            spriteRenderers[i] = faceGameObjects[i].GetComponent<SpriteRenderer>();
        }

        sprites = new Sprite[4];

        //Set answer panel
        answerPanel = GameObject.FindGameObjectWithTag("Answer");
        answerPanelScript = answerPanel.GetComponent<FaceAnswerPanel>();

        //Load Face Data
        faces = Faces.Load("FacesData");
        facesArray = faces.facesArray;
        faceArrayRand = new Face[facesArray.Length];

        //shuffle question order
        faceArrayRand = ShuffleFaceArray(facesArray);
        SetCorrectID();

        SetPrompt(prompt);
        answerPanelScript.SetExplanationTextAndImage(faceArrayRand[currentQuestion]);
    }

    public void CheckAnswer()
    {

        for (int i = 0; i < correctIds.Length; i++)
        {
            if (!string.Equals(correctIds[i],answerIds[i]))
            {
                isCorrect = false; //if wrong sets to false

                //Debug.Log(correctIds[i]);
                //Debug.Log(answerIds[i]);
            }
        }

        answerPanelScript.SetCorrectTextAndColour(isCorrect);
        answerPanelScript.SetExplanationTextAndImage(faceArrayRand[currentQuestion]);
        //play sound and add reward if true
        if (isCorrect == true)
        {
            
            gameObject.GetComponent<PlaySoundScript>().PlaySound(true);
            rewardScript.Score += 1;

            Debug.Log("Correct");
        }
        //if wrong show explanation
        else
        {
            //play normal audio (this script already attached to game manager
            gameObject.GetComponent<PlaySoundScript>().PlaySound(false);


            Debug.Log("Incorrect");
        }
        
    }

    public void LoadNextFace()
    {
        //reset isCorrect to true
        isCorrect = true;

        if (currentQuestion < faceArrayRand.Length - 1)
        {
            currentQuestion += 1;
        }
        else
        {
            //add reward then load home screen
            rewardScript.AddReward();
            sceneHandleScript.OpenScene("Home");
        }

        SetCorrectID();
        SetPrompt(prompt);

        foreach (GameObject face in faceGameObjects)
        {
            face.GetComponent<SetFace>().SetRandomSprite();
        }
    }


    //Sets Ids for correct answers
    private void SetCorrectID()
    {
        correctIds = faceArrayRand[currentQuestion].faceIds;
    }

    //Sets IDs for player answers
    public void SetAnswerID()
    {
        for (int i=0; i < sprites.Length; i++)
        {
            sprites[i] = spriteRenderers[i].sprite;
            answerIds[i] = sprites[i].name;
        }
    }

    //Shuffles array so question order is different every time player loads scene
    public Face[] ShuffleFaceArray(Face[] faceArray)
    {
        System.Random rand = new System.Random();
        int randElement;
        Face[] array = new Face[faceArray.Length];

        for (int i = 0; i < faceArray.Length; i++)
        {
            randElement = rand.Next(0, faceArray.Length);

            while (faceArray[randElement] == null) // check element is not null
            {
                randElement = rand.Next(0, faceArray.Length);
            }
            array[i] = faceArray[randElement];
            faceArray[randElement] = null; //set to null to prevent duplicates         
        }

        return array;
    }

    //Sets Question prompt
    private void SetPrompt(Text promptText)
    {
        promptText.text = faceArrayRand[currentQuestion].emotion;
    }

    
}
