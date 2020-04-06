using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    int currentSceneIndex;



   public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
