using UnityEngine;
using UnityEngine.UI;
using NewtonVR;

//Opens the safe if the correct combination is entered
public class SafeOpener : MonoBehaviour {

    public Text letter1;
    public Text letter2;
    public Text letter3;
    public BoxCollider doorCollider;
    public string correctLetter1 = "X";
    public string correctLetter2 = "Y";
    public string correctLetter3 = "Z";

    public GameObject card;
    public bool isOpen = false;

    private AudioSource openSound;

    private void Awake()
    {
        openSound = GetComponent<AudioSource>();
    }

	void Update () {
        if (!isOpen)
        {
            if(letter1.text.Equals(correctLetter1) && letter2.text.Equals(correctLetter2) && letter3.text.Equals(correctLetter3))
            {
                isOpen = true;
                openSound.Play();
                GetComponent<BoxCollider>().enabled = true;
                card.SetActive(true);
                doorCollider.enabled = true;
            }
        }
	}
}
