using UnityEngine;
using NewtonVR;
using System.Collections;

public class PuzzleController : MonoBehaviour
{

    public bool solved = false;

    public float timeBeforeNextButton = 2;
    public float timeToPress = 5;

    public Color activeButtonColor;

    public NVRButton startButton;

    public NVRButton gameButton1;
    public NVRButton gameButton2;
    public NVRButton gameButton3;
    public NVRButton gameButton4;
    public NVRButton gameButton5;

    public AudioSource failSound;
    public AudioSource activeButtonSound;
    public AudioSource successSound;
    public AudioSource startSound;

    private bool isGameStarted = false;
    private int roundNo;
    private Color initialColor;
    private Color emissionColor;
    private float counter;
    private bool count;

    private void Awake()
    {
        initialColor = gameButton1.GetComponent<Renderer>().materials[0].color;
        emissionColor = gameButton1.gameObject.GetComponent<Renderer>().materials[0].GetColor("_EmissionColor");
    }

    void Update()
    {
        if (!isGameStarted && startButton.ButtonDown)
        {
            StartGame();
        }
        if (isGameStarted)
        {
            if (count)
            {
                counter += Time.deltaTime;
            }
            if (counter > timeToPress)
                Fail();
            if (roundNo == 1 && gameButton1.ButtonDown)
                Success();
            if (roundNo == 2 && gameButton2.ButtonDown)
                Success();
            if (roundNo == 3 && gameButton3.ButtonDown)
                Success();
            if (roundNo == 4 && gameButton4.ButtonDown)
                Success();
            if (roundNo == 5 && gameButton5.ButtonDown)
                Success();
            if (roundNo == 6)
            {
                solved = true;
                Debug.Log("You're free to go");
                ResetButtonColor();
            }
        }

    }

    private void StartGame()
    {
        Debug.Log("Started Game");
        startSound.Play();
        isGameStarted = true;
        roundNo = 1;
        NextRoundStarter();
    }

    private void Fail()
    {
        roundNo++;
        ResetButtonColor();
        Debug.Log("Fail");
        isGameStarted = false;
        failSound.Play();
        count = false;
        counter = 0f;
    }

    private void Success()
    {
        Debug.Log("Success");
        successSound.Play();
        count = false;
        counter = 0f;
        roundNo++;
        NextRoundStarter();
    }

    private IEnumerator ShowButton(NVRButton button)
    {
        yield return new WaitForSeconds(timeBeforeNextButton);
        button.gameObject.GetComponent<Renderer>().materials[0].color = activeButtonColor;
        button.gameObject.GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", activeButtonColor);
        activeButtonSound.Play();
       
        count = true;
    }

    private  void NextRoundStarter()
    {
        switch (roundNo)
        {
            case 1:
                StartCoroutine(ShowButton(gameButton1));
                break;
            case 2:
                ResetButtonColor();
                StartCoroutine(ShowButton(gameButton2));
                break;
            case 3:
                ResetButtonColor();
                StartCoroutine(ShowButton(gameButton3));
                break;
            case 4:
                ResetButtonColor();
                StartCoroutine(ShowButton(gameButton4));
                break;
            case 5:
                ResetButtonColor();
                StartCoroutine(ShowButton(gameButton5));
                break;
        }
    }

    private void ResetButtonColor()
    {
        switch (roundNo)
        {
            case 2:
                gameButton1.gameObject.GetComponent<Renderer>().materials[0].color = initialColor;
                gameButton1.gameObject.GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", emissionColor);
                break;
            case 3:
                gameButton2.gameObject.GetComponent<Renderer>().materials[0].color = initialColor;
                gameButton2.gameObject.GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", emissionColor);
                break;
            case 4:
                gameButton3.gameObject.GetComponent<Renderer>().materials[0].color = initialColor;
                gameButton3.gameObject.GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", emissionColor);
                break;
            case 5:
                gameButton4.gameObject.GetComponent<Renderer>().materials[0].color = initialColor;
                gameButton4.gameObject.GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", emissionColor);
                break;
            case 6:
                gameButton5.gameObject.GetComponent<Renderer>().materials[0].color = initialColor;
                gameButton5.gameObject.GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", emissionColor);
                break;
        }
    }
}
