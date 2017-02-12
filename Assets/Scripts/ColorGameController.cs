using UnityEngine;
using NewtonVR;

  
public class ColorGameController : MonoBehaviour {

    public ColorGameStartButton StartButton;

    public ColorGameButton BlueButton;
    public ColorGameButton RedButton;
    public ColorGameButton GreenButton;
    public ColorGameButton VioletButton;
    public ColorGameButton BrownButton;
    public ColorGameButton OrangeButton;

    public LightController lightController;
    public float speed = 0.8f;

    private ColorGameButton correctButton;
    private int roundNo = 0;
    
    private void Update()
    {
        if (StartButton.ButtonDown)
        {
            StartGame();
        }
        if (BlueButton.ButtonDown)
        {
            if(correctButton != BlueButton)
            {
                lightController.StartCoroutine("BlinkRed");
            }else
            {
                if (roundNo == 1)
                {
                    correctButton = GreenButton;
                }else if(roundNo == 2)
                {
                    correctButton = BrownButton;
                }else
                {
                    lightController.StartCoroutine("ShowCorrectCombination");
                }
            }
        }
        if (RedButton.ButtonDown)
        {
            if (correctButton != RedButton)
            {
                lightController.StartCoroutine("BlinkRed");
            }else
            {
                if (roundNo == 1)
                {
                    lightController.StartCoroutine("ShowSecondRoundColors");
                    roundNo = 2;
                    correctButton = OrangeButton;
                }
                else if(roundNo == 3)
                {
                    correctButton = BlueButton;
                }
            }
        }
        if (GreenButton.ButtonDown)
        {
            if (correctButton != GreenButton)
            {
                lightController.StartCoroutine("BlinkRed");
            }
            else
            {
                correctButton = RedButton;
            }
        }
        if (VioletButton.ButtonDown)
        {
            if (correctButton != VioletButton)
            {
                lightController.StartCoroutine("BlinkRed");
            }
            else if(roundNo == 2)
            {
                correctButton = BlueButton;
            }
            else if (roundNo == 3)
            {
                correctButton = OrangeButton;
            }

        }
        if (BrownButton.ButtonDown)
        {
            if (correctButton != BrownButton)
            {
                lightController.StartCoroutine("BlinkRed");
            }
            else 
            {
                lightController.StartCoroutine("ShowThirdRoundColors");
                roundNo = 3;
                correctButton = VioletButton;
            }
        }
        if (OrangeButton.ButtonDown)
        {
            if (correctButton != OrangeButton)
            {
                lightController.StartCoroutine("BlinkRed");
            }
            else if (roundNo == 2)
            {
                correctButton = VioletButton;
            }
            else
            {
                correctButton = GreenButton;
            }
        }
    }

    private void StartGame()
    {
        Debug.Log("Game Started");
        lightController.StartCoroutine("StartFirstRound");
        roundNo = 1;
        correctButton = BlueButton;
    }
}
