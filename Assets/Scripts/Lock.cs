using UnityEngine;
using NewtonVR;

public class Lock : MonoBehaviour {

    public TextMesh LetterSpinner1Val;
    public TextMesh LetterSpinner2Val;
    public TextMesh LetterSpinner3Val;
    public GameObject Knob;
    public Rigidbody Door;

    private AudioSource openSound;

    private void Awake()
    {
        openSound = GetComponent<AudioSource>();

     }
   

	void Update () {
        if (LetterSpinner1Val.text == "X" && LetterSpinner2Val.text == "Y" && LetterSpinner3Val.text == "Z")
        {
            Knob.GetComponent<NVRInteractableItem>().enabled = true;
            openSound.Play();
        }
	}
}
