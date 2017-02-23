using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class DoorButtonSoundManager : MonoBehaviour {

    public NVRButton button1;
    public NVRButton button2;
    public NVRButton button3;
    public NVRButton button4;
    public NVRButton button5;
    public NVRButton button6;
    public NVRButton button7;
    public NVRButton button8;
    public NVRButton button9;


    public AudioSource buttonPressedSound;

	void Update () {
        if (button1.ButtonDown || button2.ButtonDown || button3.ButtonDown || button4.ButtonDown || button5.ButtonDown || button6.ButtonDown || button7.ButtonDown || button8.ButtonDown || button9.ButtonDown)
            buttonPressedSound.Play();

    }
}
