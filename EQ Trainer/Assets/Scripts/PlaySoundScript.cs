using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScript : MonoBehaviour
{
    private GameObject[] sounds;
    private AudioSource clickSound;
    private AudioSource correctSound;

    void Start()
    {
        sounds = GameObject.FindGameObjectsWithTag("Sound");

        clickSound = sounds[0].GetComponent<AudioSource>();
        correctSound = sounds[1].GetComponent<AudioSource>();
    }


    public void PlaySound(bool isCorrect)
    {
        if(isCorrect == true)
        {
            correctSound.Play();
        }
        else
        {
            clickSound.Play();
        }
    }

    }

