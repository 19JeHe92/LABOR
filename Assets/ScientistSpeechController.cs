using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistSpeechController : MonoBehaviour
{

    public float secondsBeforeSpeechStart = 10f; //30 seconds for you

    private AudioSource speechSound;
    private bool speechStarted = false;

    public void Awake()
    {
        speechSound = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (secondsBeforeSpeechStart > 0)
        {
            secondsBeforeSpeechStart -= Time.deltaTime;
        }
        else
        {
            if (!speechStarted)
            {
                speechSound.Play();
                speechStarted = true;
                Debug.Log("Scientist speech");
            }
        }
    }

}