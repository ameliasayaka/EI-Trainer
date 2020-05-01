using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    //put renderers into array
    private GameObject[] faceGameObjects;
    private SpriteRenderer[] spriteRenderers;
    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
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

        faces = Faces.Load("Assets/Data/FacesData.xml");
        facesArray = faces.facesArray;
        faceArrayRand = new Face[facesArray.Length];

        //shuffle question order
        faceArrayRand = ShuffleFaceArray(facesArray);
        SetCorrectID();

    }

    public void CheckAnswer()
    {

        for (int i = 0; i < correctIds.Length; i++)
        {
            if (!Equals(correctIds[i],answerIds[i]))
            {
                isCorrect = false; //if wrong sets to false
            }
        }

        //if correct add reward
        if (isCorrect == true)
        {

        }
        //if wrong show correct with explanation
    }

    public void LoadNextFace()
    {
        //reset isCorrect to true
        isCorrect = true;

        if(currentQuestion < faceArrayRand.Length -1)
        {
            currentQuestion += 1;
        }
        SetCorrectID();
    }

    private void SetCorrectID()
    {
        correctIds = faceArrayRand[currentQuestion].faceIds;
    }

    public void SetAnswerID()
    {
        for (int i=0; i < sprites.Length; i++)
        {
            sprites[i] = spriteRenderers[i].sprite;
            answerIds[i] = sprites[i].name;
        }
    }
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
}
