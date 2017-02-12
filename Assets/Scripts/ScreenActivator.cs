using UnityEngine;
using NewtonVR;

public class ScreenActivator : MonoBehaviour {

    public ScreenButton Button;
    public GameObject Screen;

    private void Update()
    {
        if (Button.ButtonDown)
        {
            Screen.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 0.0f, 0.7f); ;
        }
    }
}
