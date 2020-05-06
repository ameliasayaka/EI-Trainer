using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceAnswerPanel : MonoBehaviour
{
    public Sprite angerFace;
    public Sprite happyFace;
    public Sprite sadFace;
    public Sprite surpriseFace;
    public Sprite disgustFace;
    public Sprite fearFace;

    private Text explanationText;
    private Text correctText;
    private Image faceImage;

    private Color green;
    private Color32 red;
    private Image panelImage;
    // Start is called before the first frame update
    void Start()
    {
        explanationText = GameObject.FindGameObjectWithTag("Explanation").GetComponent<Text>();
        correctText = GameObject.FindGameObjectWithTag("CorrectText").GetComponent<Text>();
        faceImage = GameObject.FindGameObjectWithTag("FaceImage").GetComponent<Image>();

        green = new Color(0.2f , 0.7f , 0.4f);
        red = new Color(0.7f, 0.2f, 0.2f);
        panelImage = gameObject.GetComponent<Image>();
    }

    public void SetExplanationTextAndImage(Face face)
    {
        string caseSwitch = face.emotion;

        switch (caseSwitch)
        {
            case "Anger":
                faceImage.sprite = angerFace;
                
            break;
            case "Happy":
                faceImage.sprite = happyFace;
           
                break;
            case "Fear":
                faceImage.sprite = fearFace;

                break;
            case "Sad":
                faceImage.sprite = sadFace;

                break;
            case "Surprise":
                faceImage.sprite = surpriseFace;

                break;
            case "Disgust":
                faceImage.sprite = disgustFace;

                break;
            default:
                Debug.Log("Something terrible happened here...");
                break;
        }
        explanationText.text = face.explanation;
    }

    public void SetCorrectTextAndColour(bool isCorrect)
    {
        if (isCorrect)
        {
            correctText.text = "Correct!";
            panelImage.color = green;
        }
        else
        {
            correctText.text = "Not Quite!";
            panelImage.color = red;
        }
    }
}
