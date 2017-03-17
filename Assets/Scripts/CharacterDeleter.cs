using UnityEngine;
using NewtonVR;

//Deletes characters from the display if the delete button is pressed
public class CharacterDeleter : MonoBehaviour {

    public DisplayManager display;

    private NVRButton button;

    private void Awake()
    {
        button = GetComponent<NVRButton>();
    }

	void Update ()
    {
        if (button.ButtonDown)
        {
            display.DeleteCharacter();
        }
	}
}
