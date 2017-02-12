using UnityEngine;
using NewtonVR;
using System.Collections;

public class DoorOpener : MonoBehaviour {

    public DoorButton button1;
    public DoorButton button2;
    public DoorButton button3;
    public DoorButton button4;
    public RobotContoller robot;

    public GameObject CardLight;
    public GameObject Combinationlight;

    public NVRAttachPoint Card;

    public bool isCorrectCombinationEntered = false;
    public bool isCardInserted = false;

    public Transform End;

    private int nrOfCorrectButtons = 0;
    public float speed = 0.2f;
    private void Update()
    {
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
        if (isCorrectCombinationEntered && isCardInserted)
        {
            StartCoroutine("Open");
            robot.run = true; 
        }
    }

    private IEnumerator BlinkRed()
    {
        Combinationlight.GetComponent<Renderer>().materials[1].color = Color.red;
        yield return new WaitForSeconds(1);
        Combinationlight.GetComponent<Renderer>().materials[1].color = Color.white;

    }

    private IEnumerator Open()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime/speed;
           transform.position = Vector3.Lerp(transform.position, End.position, timeSinceStarted);

            if (transform.position == End.position)
            {
                yield break;
            }
            yield return null;
        }
    }
}
            
