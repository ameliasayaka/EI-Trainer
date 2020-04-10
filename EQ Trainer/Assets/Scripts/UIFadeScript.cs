using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script for fading in and out canvas groups
public class UIFadeScript : MonoBehaviour
{
    //public CanvasGroup canvasGroup;
    public float fadeDuration = 5f; //default duration. Can be changed in Unity Editor
    

    public void Fade(CanvasGroup canvasGroup, bool isFadeIn)
    {
        
        //Checks if canvas is to be faded in or out
        if (isFadeIn == true)
        {
            //enable canvas before fade in
            
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            //Debug.Log(canvasGroup);
            StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, 1));
        }
        else if (isFadeIn == false)
        {
            StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, 0));

            //disable canvas
            canvasGroup.blocksRaycasts = false;
        }
        
    }

    public IEnumerator DoFade(CanvasGroup canvas, float start, float end)
    {
        float count = 0f;
        //Debug.Log("Fading");
        //Debug.Log(canvas.alpha);
        while (count < fadeDuration)
        {
            count += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(start, end, count / fadeDuration);
            //Debug.Log(canvas.alpha);
            yield return null;
        }

        yield return null;
    }
}
