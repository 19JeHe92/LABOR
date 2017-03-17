using UnityEngine;
using NewtonVR;

public class YellowPuzzle : MonoBehaviour
{

    public NVRAttachJoint KeyJoint;
    public NVRAttachJoint CardJoint;
    public NVRAttachJoint ChipJoint;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;

    private bool keySolved = false;
    private bool chipSolved = false;
    private bool cardSolved = false;
    private bool isCorrectCombiantionEntered = false;

    public NVRButton button1;
    public NVRButton button2;
    public NVRButton button3;
    public NVRButton button4;

    public bool solved = false;
    private int nrOfCorrectButtons = 0;

    public AudioSource failSound;
    private void Fail()
    {
        failSound.Play();
    }

    void Update()
    {
        if (light1.active && light2.active && light3.active && light4.active)
        {
            solved = true;
        }

        if (!keySolved && KeyJoint.AttachedItem && KeyJoint.AttachedItem.gameObject.tag == "key")
        {
            keySolved = true;
            Debug.Log("Key Insterted");
            light2.active = true;
        }
        if (!chipSolved && ChipJoint.AttachedItem && ChipJoint.AttachedItem.gameObject.tag == "chip")
        {
            chipSolved = true;
            Debug.Log("Chip Insterted");
            light3.active = true;
        }
        if (!cardSolved && CardJoint.AttachedItem && CardJoint.AttachedItem.gameObject.tag == "Card")
        {
            cardSolved = true;
            Debug.Log("Card Insterted");
            light1.active = true;
        }

        if (button1.ButtonDown)
        {
            if (nrOfCorrectButtons == 0)
            {
                nrOfCorrectButtons++;
                Debug.Log("First correct Button");
            }
            else
            {
                Fail();
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
                Fail();
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
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
        if (button4.ButtonDown)
        {
            if (nrOfCorrectButtons == 3)
            {
                light4.active = true;
                Debug.Log("Fourth correct Button");
                isCorrectCombiantionEntered = true;
            }
            else
            {
                Fail();
                nrOfCorrectButtons = 0;
            }
        }
    }
}
