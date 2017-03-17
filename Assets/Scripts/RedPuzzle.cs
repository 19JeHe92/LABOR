using UnityEngine;
using NewtonVR;


public class RedPuzzle : MonoBehaviour
{

    public NVRButton button1;
    public NVRButton button2;
    public NVRButton button3;
    public NVRButton button4;
    public NVRButton button5;
    public NVRButton button6;
    public NVRButton button7;
    public NVRButton button8;
    public NVRButton button9;
    public NVRButton button10;
    public NVRButton button11;
    public NVRButton button12;
    public NVRButton button13;
    public NVRButton button14;
    public float pressBias = 1f;

    private float counter = 0;
    public GameObject light;

    public AudioSource failSound;
    public AudioSource correctSound;

    private int nrOfCorrectButtons = 0;
    private bool isCounting = false;
    public bool solved;
    private bool areButtonsDisabled = false;

    private void Fail()
    {
        failSound.Play();
    }

    void Update()
    {
        if (light.active)
        {
            solved = true;
        }


        if (isCounting)
        {
            counter += Time.deltaTime;
            if (counter > pressBias)
            {
                counter = 0f;
                isCounting = false;
                areButtonsDisabled = false;
            }
        }
        if (!areButtonsDisabled)
        {
            if (button1.ButtonDown && nrOfCorrectButtons == 0)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 0)
                {
                    Debug.Log("FirstCorrectbutton");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("Fail at first button");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button2.ButtonDown && nrOfCorrectButtons == 1)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 1)
                {
                    Debug.Log("SecondCorrect");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("Secondfail");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button3.ButtonDown && nrOfCorrectButtons == 2)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 2)
                {
                    Debug.Log("3 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("3-");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button4.ButtonDown && nrOfCorrectButtons == 3)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 3)
                {
                    Debug.Log("4 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("4 -");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button5.ButtonDown && nrOfCorrectButtons == 4)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 4)
                {
                    Debug.Log("5 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("5 -");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button6.ButtonDown && nrOfCorrectButtons == 5)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 5)
                {
                    Debug.Log("6 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("6 +");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button7.ButtonDown && nrOfCorrectButtons == 6)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 6)
                {
                    Debug.Log("7 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("7 -");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button8.ButtonDown && nrOfCorrectButtons == 7)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 7)
                {
                    Debug.Log("8 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("8 -");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button9.ButtonDown && nrOfCorrectButtons == 8)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 8)
                {
                    Debug.Log("9 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("9 -");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button10.ButtonDown && nrOfCorrectButtons == 9)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 9)
                {
                    Debug.Log("10 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("10 -");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button11.ButtonDown && nrOfCorrectButtons == 10)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 10)
                {
                    Debug.Log("11 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("11-");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button12.ButtonDown && nrOfCorrectButtons == 11)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 11)
                {
                    Debug.Log("12 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("12 -");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button13.ButtonDown && nrOfCorrectButtons == 12)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 12)
                {
                    Debug.Log("13 +");
                    nrOfCorrectButtons++;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("13 -");
                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
            else if (button14.ButtonDown && nrOfCorrectButtons == 13)
            {
                DisableButtons();
                if (nrOfCorrectButtons == 13)
                {
                    light.active = true;
                    Debug.Log("Last correct Button");
                    solved = true;
                    correctSound.Play();
                }
                else
                {
                    Debug.Log("14 +");

                    Fail();
                    nrOfCorrectButtons = 0;
                }
            }
        }
    }
    private void DisableButtons()
    {
        isCounting = true;
        areButtonsDisabled = true;
    }
}
