using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioHandler : MonoBehaviour
{
    private string fileName = "testScenarioData.xml";
    [SerializeField]
    private Text scenarioText;
    [SerializeField]
    private Text[] buttonList;

    // Start is called before the first frame update
    void Start()
    {
        LoadScenario();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScenario()
    {

    }
}
