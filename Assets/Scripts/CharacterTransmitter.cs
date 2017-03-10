using UnityEngine;
using NewtonVR;

public class CharacterTransmitter : MonoBehaviour {

    public DisplayManager displayManager;
    public DisplayManager.Characters character;

    private NVRButton button;

    void Awake()
    {
        button = GetComponent<NVRButton>();
    }

    void Update()
    {
        if (button.ButtonDown)
        {
            displayManager.ReceiveCharacter(character);
        }
    }
}
