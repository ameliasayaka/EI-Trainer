using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IntroSceneScript : MonoBehaviour /*IPointerClickHandler*/
{
    public CanvasGroup initialCanvasGroup;
    public CanvasGroup secondCanvasGroup;
    private CanvasGroup currentCanvas;
    bool isFadeIn;
    private UIFadeScript fadeScript;
    private GameObject gameManager;
    private Touch touch;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        fadeScript = gameManager.GetComponent<UIFadeScript>();
        isFadeIn = true;
        currentCanvas = initialCanvasGroup;
        touch = new Touch();
        
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
        if (initialCanvasGroup.interactable == false && initialCanvasGroup.alpha == 0f)
        {
            
            fadeScript.Fade(secondCanvasGroup, true);
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
