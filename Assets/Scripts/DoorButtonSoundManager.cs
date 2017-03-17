using UnityEngine;
using NewtonVR;

//Plays a sound if a button on the door is pressed
//Note: the SoundPlayer script should be attached to the button. But since we introduced sounds only at the end it was easyer to do it this way
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

    public bool isCardFound = false;
    public bool isCombinationFound = false;

    public AudioSource findCardHint;
    public AudioSource findCardAndCodeHint;

    public AudioSource buttonPressedSound;

	void Update () {
        if (button1.ButtonDown || button2.ButtonDown || button3.ButtonDown || button4.ButtonDown || button5.ButtonDown || button6.ButtonDown || button7.ButtonDown || button8.ButtonDown || button9.ButtonDown)
        { 
            buttonPressedSound.Play();
            if (!isCombinationFound)
                findCardAndCodeHint.Play();
            else if (!isCardFound)
                findCardHint.Play();
        }
    }
}
