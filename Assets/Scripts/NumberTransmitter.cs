using UnityEngine;
using NewtonVR;

public class NumberTransmitter : MonoBehaviour {

    public DisplayManager displayManager;
    public int number;

    private NVRButton button;

    void Awake()
    {
        button = GetComponent<NVRButton>();
    }

    void Update()
    {
        if (button.ButtonDown)
        {
            displayManager.ReceiveNumber(number);
        }
    }
}
