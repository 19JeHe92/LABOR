using UnityEngine;
using NewtonVR;

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
            display.deleteCharacter();
        }
	}
}
