using UnityEngine;
using NewtonVR;

public class ColorGameController : MonoBehaviour
{

    public SimonButtons[] round1Sol;
    public SimonButtons[] round2Sol;
    public SimonButtons[] round3Sol;

    public NVRButton StartButton;
    public float pressBias = 2f;

    public NVRButton Button1;
    public NVRButton Button2;
    public NVRButton Button3;
    public NVRButton Button4;
    public NVRButton Button5;
    public NVRButton Button6;

    public AudioSource startSound;
    public AudioSource correctSound;
    public AudioSource failSound;
    public AudioSource wonSound;
    public AudioSource buttonSound;

    public DoorButtonSoundManager hintManager;
    public LightController lightController;
    public float speed = 0.8f;
    private float counter = 0f;

    private NVRButton correctButton;
    private int roundNo = 0;
    public bool isGameSolved = false;
    private bool isGameStarted = false;
    private bool isCounting = false;
    private bool areButtonsDisabled = false;
    private SimonButtons[] currentSol;
    private int currentIndex = 0;

    private void Update()
    {
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

        if (StartButton.ButtonDown && !isGameStarted)
        {
            StartGame();
            isGameStarted = true;
            DisableButtons();
        }
        if (isGameStarted && !areButtonsDisabled)
        {
            if (Button1.ButtonDown)
            {
                CheckInput(SimonButtons.first);
            }
            if (Button2.ButtonDown)
            {
                CheckInput(SimonButtons.second);
            }
            if (Button3.ButtonDown)
            {
                CheckInput(SimonButtons.third);
            }
            if (Button4.ButtonDown)
            {
                CheckInput(SimonButtons.forth);

            }
            if (Button5.ButtonDown)
            {
                CheckInput(SimonButtons.fifth);
            }
            if (Button6.ButtonDown)
            {
                CheckInput(SimonButtons.sixth);
            }
        }
    }

    private void StartGame()
    {
        startSound.Play();
        Debug.Log("Game Started");
        lightController.StartCoroutine("StartFirstRound");
        roundNo = 1;
        currentSol = round1Sol;
    }

    private void failed()
    {
        failSound.Play();
        lightController.StartCoroutine("BlinkRed");
        isGameStarted = false;
        currentIndex = 0;
    }

    private void DisableButtons()
    {
        isCounting = true;
        areButtonsDisabled = true;
    }

    private void CheckInput(SimonButtons correct)
    {
        buttonSound.Play();
        DisableButtons();
        if (currentSol[currentIndex] != correct)
        {
            failed();
        }
        else
        {
            if (currentIndex < currentSol.Length - 1)
                currentIndex++;
            else
            {
                SolvedRound();
                currentIndex = 0;
            }
        }
    }

    private void SolvedRound()
    {
        correctSound.Play();
        if (currentSol == round1Sol)
        {
            lightController.StartCoroutine("ShowSecondRoundColors");
            currentSol = round2Sol;
        }
        else if (currentSol == round2Sol)
        {
            lightController.StartCoroutine("ShowThirdRoundColors");
            currentSol = round3Sol;
        }
        else
            Won();
    }

    private void Won()
    {
        wonSound.Play();
        hintManager.isCombinationFound = true;
        lightController.StartCoroutine("ShowCorrectCombination");
        isGameSolved = true;
    }

    public enum SimonButtons
    {
        first, second, third, forth, fifth, sixth
    }
}
