using UnityEngine;
using NewtonVR;
using System.Collections;

//Opens the door in the first room is the card has been inserted and the correct combination has been entered
public class DoorOpener : MonoBehaviour {

    public NVRButton button1;
    public NVRButton button2;
    public NVRButton button3;
    public NVRButton button4;

    public GameObject teleporterBlockingObject;
    public GameObject cardLight;
    public GameObject combinationlight;

    public NVRAttachPoint card;
    public float speed = 0.2f;

    public bool isCorrectCombinationEntered = false;
    public bool isCardInserted = false;

    public Transform End;
    public AudioSource openedSound;

    private int nrOfCorrectButtons = 0;
    private bool soundPlayed = false;

    private void Update()
    {
        if (isCardInserted && isCorrectCombinationEntered)
        {
            if (!soundPlayed)
            {
                teleporterBlockingObject.active = false;
                openedSound.Play();
                soundPlayed = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, End.position, Time.deltaTime*speed);
        }
        if (card.IsAttached)
        {
            isCardInserted = true;
            cardLight.GetComponent<Renderer>().materials[1].color = Color.green;
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
                combinationlight.GetComponent<Renderer>().materials[1].color = Color.green;
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

    //makes the light blink red if the pressed button is wrong
    private IEnumerator BlinkRed()
    {
        combinationlight.GetComponent<Renderer>().materials[1].color = Color.red;
        yield return new WaitForSeconds(1);
        combinationlight.GetComponent<Renderer>().materials[1].color = Color.white;

    }

   
}
            
