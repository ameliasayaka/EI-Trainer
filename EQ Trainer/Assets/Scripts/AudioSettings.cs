using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private int volume;
    private AudioSource bgm;
    private DataHolder dataHolderScript;
    public Slider volumeSlider;
    private float volumePercent;
    public Text volumeText;

    // Start is called before the first frame update
    void Start()
    {
        dataHolderScript = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        bgm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();
        bgm.volume = dataHolderScript.player.volume;
        volumeSlider.value = bgm.volume;
        volumePercent = bgm.volume * 100;

        volumeText.text = "Volume: " + (int)volumePercent + "%";
    }

    public void SaveVolume()
    {

        dataHolderScript.player.volume = bgm.volume;
        SaveLoadPlayerData.SaveData(dataHolderScript.player);
        
    }
    public void DisplayVolumePercent()
    {
        volumePercent = bgm.volume * 100;
        volumeText.text = "Volume: " + (int)volumePercent + "%";

    }
}
