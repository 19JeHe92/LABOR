﻿using UnityEngine;
using NewtonVR;
using System.Collections;

public class DoorOpener : MonoBehaviour {

    public NVRButton button1;
    public NVRButton button2;
    public NVRButton button3;
    public NVRButton button4;

    public GameObject TeleporterBlockingObject;
    public GameObject CardLight;
    public GameObject Combinationlight;

    public NVRAttachPoint Card;

    public bool isCorrectCombinationEntered = false;
    public bool isCardInserted = false;

    public Transform End;
    public AudioSource openedSound;

    private int nrOfCorrectButtons = 0;
    public float speed = 0.2f;
    private bool soundPlayed = false;
    private void Update()
    {
        if (isCardInserted && isCorrectCombinationEntered)
        {
            if (!soundPlayed)
            {
                TeleporterBlockingObject.active = false;
                openedSound.Play();
                soundPlayed = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, End.position, Time.deltaTime*speed);
        }
        if (Card.IsAttached)
        {
            isCardInserted = true;
            CardLight.GetComponent<Renderer>().materials[1].color = Color.green;
        }
        if (button1.ButtonDown )
        {
            if (nrOfCorrectButtons == 0) {
                nrOfCorrectButtons++;
                Debug.Log("First correct Button");
            }
            else
            {
                StartCoroutine("BlinkRed");
                nrOfCorrectButtons = 0;
            }
        }
        if (button2.ButtonDown)
        {
            if (nrOfCorrectButtons == 1)
            {
                Debug.Log("Second correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                StartCoroutine("BlinkRed");
                nrOfCorrectButtons = 0;
            }
        }
        if (button3.ButtonDown)
        {
            if (nrOfCorrectButtons == 2)
            {
                Debug.Log("Third correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                StartCoroutine("BlinkRed");
                nrOfCorrectButtons = 0;
            }
        }
        if (button4.ButtonDown)
        {
            if (nrOfCorrectButtons == 3)
            {
                Combinationlight.GetComponent<Renderer>().materials[1].color = Color.green;
                Debug.Log("Fourth correct Button");
                isCorrectCombinationEntered = true;
            }
            else
            {
                StartCoroutine("BlinkRed");
                nrOfCorrectButtons = 0;
            }
        }
    }

    private IEnumerator BlinkRed()
    {
        Combinationlight.GetComponent<Renderer>().materials[1].color = Color.red;
        yield return new WaitForSeconds(1);
        Combinationlight.GetComponent<Renderer>().materials[1].color = Color.white;

    }

   
}
            
