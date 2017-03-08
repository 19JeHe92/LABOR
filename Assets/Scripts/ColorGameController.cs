using UnityEngine;
using NewtonVR;

  
public class ColorGameController : MonoBehaviour {

    public NVRButton StartButton;

    public NVRButton Button1;
    public NVRButton Button2;
    public NVRButton Button3;
    public NVRButton Button4;
    public NVRButton Button5;
    public NVRButton Button6;
    public bool isGameSolved = false;
    public DoorButtonSoundManager hintManager;
    public LightController lightController;
    public float speed = 0.8f;

    private NVRButton correctButton;
    private int roundNo = 0;
    
    private void Update()
    {
        if (StartButton.ButtonDown)
        {
            StartGame();
        }
        if (Button1.ButtonDown)
        {
            if(correctButton != Button1)
            {
                lightController.StartCoroutine("BlinkRed");
            }else
            {
                if (roundNo == 1)
                {
                    correctButton = Button3;
                }else if(roundNo == 2)
                {
                    correctButton = Button5;
                }else
                {
                    lightController.StartCoroutine("ShowCorrectCombination");
                }
            }
        }
        if (Button2.ButtonDown)
        {
            if (correctButton != Button2)
            {
                lightController.StartCoroutine("BlinkRed");
            }else
            {
                if (roundNo == 1)
                {
                    lightController.StartCoroutine("ShowSecondRoundColors");
                    roundNo = 2;
                    correctButton = Button6;
                }
                else if(roundNo == 3)
                {
                    correctButton = Button1;
                }
            }
        }
        if (Button3.ButtonDown)
        {
            if (correctButton != Button3)
            {
                lightController.StartCoroutine("BlinkRed");
            }
            else
            {
                correctButton = Button2;
            }
        }
        if (Button4.ButtonDown)
        {
            if (correctButton != Button4)
            {
                lightController.StartCoroutine("BlinkRed");
            }
            else if(roundNo == 2)
            {
                correctButton = Button1;
            }
            else if (roundNo == 3)
            {
                correctButton = Button6;
            }

        }
        if (Button5.ButtonDown)
        {
            if (correctButton != Button5)
            {
                lightController.StartCoroutine("BlinkRed");
            }
            else 
            {
                lightController.StartCoroutine("ShowThirdRoundColors");
                roundNo = 3;
                correctButton = Button4;
            }
        }
        if (Button6.ButtonDown)
        {
            if (correctButton != Button6)
            {
                lightController.StartCoroutine("BlinkRed");
            }
            else if (roundNo == 2)
            {
                correctButton = Button4;
            }
            else
            {
                correctButton = Button3;
            }
        }
    }

    private void StartGame()
    {
        Debug.Log("Game Started");
        lightController.StartCoroutine("StartFirstRound");
        roundNo = 1;
        correctButton = Button1;
    }
}
