using System.Collections;
using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

//This is the controller for a puzzle in which the player need to play a sequence of the imperial march 
//We did not manage to integrate this script in the game (which is maybe a good think sinte it's written super inefficient)
public class ImperialMarch : MonoBehaviour
{
    public NVRButton playcompleteButton;

    public NVRButton button1;
    public NVRButton button2;
    public NVRButton button3;
    public NVRButton button4;
    public NVRButton button5;
    public NVRButton button6;

    public NVRButton correctbutton1;
    public NVRButton correctbutton2;
    public NVRButton correctbutton3;
    public NVRButton correctbutton4;
    public NVRButton correctbutton5;
    public NVRButton correctbutton6;
    public NVRButton correctbutton7;
    public NVRButton correctbutton8;
    public NVRButton correctbutton9;

    public AudioSource failSound;
    public AudioSource successSound;

    public AudioSource completeSoundTrack;
    public AudioSource button1Sound;
    public AudioSource button2Sound;
    public AudioSource button3Sound;
    public AudioSource button4Sound;
    public AudioSource button5Sound;
    public AudioSource button6Sound;

    private int nrOfCorrectButtons = 0;

    private void Update()
    {
        if (playcompleteButton.ButtonDown && !completeSoundTrack.isPlaying)
        {
            completeSoundTrack.Play();
        }

        if (correctbutton1.ButtonDown && nrOfCorrectButtons == 0)
        {
            if (nrOfCorrectButtons == 0)
            {
                successSound.Play();
                nrOfCorrectButtons++;
                Debug.Log("First correct Button");
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (correctbutton2.ButtonDown && nrOfCorrectButtons == 1)
        {
            if (nrOfCorrectButtons == 1)
            {
                successSound.Play();
                Debug.Log("Second correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (correctbutton3.ButtonDown && nrOfCorrectButtons == 2)
        {
            if (nrOfCorrectButtons == 2)
            {
                successSound.Play();
                Debug.Log("Third correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (correctbutton4.ButtonDown && nrOfCorrectButtons == 3)
        {
            if (nrOfCorrectButtons == 3)
            {
                successSound.Play();
                Debug.Log("Fourth correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (correctbutton5.ButtonDown && nrOfCorrectButtons == 4)
        {
            if (nrOfCorrectButtons == 3)
            {
                successSound.Play();
                Debug.Log("Fifth correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (correctbutton6.ButtonDown && nrOfCorrectButtons == 5)
        {
            if (nrOfCorrectButtons == 5)
            {
                successSound.Play();
                Debug.Log("sixt correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (correctbutton7.ButtonDown && nrOfCorrectButtons == 6)
        {
            if (nrOfCorrectButtons == 6)
            {
                successSound.Play();
                Debug.Log("seventh correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (correctbutton8.ButtonDown && nrOfCorrectButtons == 7)
        {
            if (nrOfCorrectButtons == 7)
            {
                successSound.Play();
                Debug.Log("eight correct Button");
                nrOfCorrectButtons++;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (correctbutton9.ButtonDown && nrOfCorrectButtons == 8)
        {
            if (nrOfCorrectButtons == 8)
            {
                successSound.Play();
                Debug.Log("last correct Button");
                
                nrOfCorrectButtons++;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
    }

    private void Fail()
    {
        failSound.Play();
    }

    private IEnumerable LoadSceneAfterSecs()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ChP7-RobotRoom");
    }

}
