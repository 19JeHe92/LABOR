using UnityEngine;
using NewtonVR;
using UnityEngine.UI;

//Sets the text to correspond to the letter spinner
public class LetterSpinnerResult : MonoBehaviour {

    public NVRLetterSpinner letterSpinner;

    private Text text;
	
	void Awake () {
        text = GetComponent<Text>();	
	}
	
	void Update () {
        text.text = letterSpinner.GetLetter();
	}
}
