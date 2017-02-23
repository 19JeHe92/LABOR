using UnityEngine;
using UnityEngine.SceneManagement;
using NewtonVR;

public class GameController : MonoBehaviour {

    public NVRHand leftController;
    public NVRHand rightController;
    public float secondsBeforeReturnToTheBrightSide = 3.0f;

    private bool holding = false;
    private float counter = 0.0f;
    
    public void Update()
    {
        if(!holding && leftController.Inputs[NVRButtons.Trigger].IsPressed && rightController.Inputs[NVRButtons.Trigger].IsPressed)
        {
            //Debug.Log("Oh! Oh! He/She's holding them!");
            holding = true;
        }
        else if(holding && (!leftController.Inputs[NVRButtons.Trigger].IsPressed || !rightController.Inputs[NVRButtons.Trigger].IsPressed))
        {
            //Debug.Log("Nope, false alarm! Trigger Buttons released");
            holding = false;
            counter = 0.0f;
        }
        if (holding)
        {
            counter += Time.deltaTime;
            if (counter > secondsBeforeReturnToTheBrightSide)
            {
                //Debug.Log("It's time to go...");
                ReturnToMainMenu();
            }
        }
    }

    public void ReturnToMainMenu()
    {
        //Debug.Log("Returning to the bright side");
        SceneManager.LoadScene("StartScene");
    }
}
