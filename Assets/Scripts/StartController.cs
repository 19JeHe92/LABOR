using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This class is the controller of the main menu
public class StartController : MonoBehaviour {

    public NVRAttachPoint Brain;
    public Fader fadeOutTexture;
    public GameObject checkpointsList;
    
    //this is a workaround
    //if checkpointslist is disabled at the beginning, the raycaster does not work correctly
    //and since we can#t open the GraphicRacaster Script we could't solve it otherwise 
    public Transform checkpointsListPosition;

	//If the brain has been attached to the scanner load the game
	void Update () {
        if (Brain.IsAttached)
        {
            //This logic is not used because we've set up the checkpoints for the SGDC so that every checkpoint is availble

            //GameDataManager.dataManager.LoadGame();
            ////If there are no saved checkpoints load the first scene
            //if (GameDataManager.dataManager.checkpoints == null)
            //{
            //    GameDataManager.dataManager.checkpoints.Add(Checkpoints.StartRoom);
            //    GameDataManager.dataManager.playerHealth = 100;
            //    GameDataManager.dataManager.SaveGame();
            //    fadeOutTexture.fadeToBlack = true;
            //    SceneManager.LoadScene("FirstRoom");
            //}
            //else let the player choose which checkpoint he want's to load
            //else
            //{
            checkpointsList.transform.position = checkpointsListPosition.position;
            //}
        }
	}

    public void LoadScene(Checkpoints checkpoint)
    {
        switch (checkpoint)
        {
            case Checkpoints.FirstRoom:
                SceneManager.LoadScene("FirstRoom");
                break;
            case Checkpoints.Floor1:
                SceneManager.LoadScene("ChP1-Floor");
                break;
            case Checkpoints.ZombieLab:
                SceneManager.LoadScene("ChP2-ZombieLab");
                break;
            case Checkpoints.RoboFloor:
                SceneManager.LoadScene("ChP3-RoboFloor");
                break;
            case Checkpoints.Smoke:
                SceneManager.LoadScene("ChP4-Smoke");
                break;
            case Checkpoints.LightsPuzzle:
                SceneManager.LoadScene("ChP5-LightsPuzzle");
                break;
            case Checkpoints.Lasers:
                SceneManager.LoadScene("ChP6-Lasers");
                break;
            case Checkpoints.RobotFactory:
                SceneManager.LoadScene("ChP7-RobotRoom");
                break;
            case Checkpoints.Height:
                SceneManager.LoadScene("ChP8-RobotRoom-Oben");
                break;
            case Checkpoints.ControlRoom:
                SceneManager.LoadScene("ChP9-RobotRoom-Control");
                break;
            case Checkpoints.Floor2:
                SceneManager.LoadScene("ChP10-FloorGenerator");
                break;
            case Checkpoints.GeneratorRoom:
                SceneManager.LoadScene("ChP11-GeneratorRoom");
                break;
            case Checkpoints.Boss:
                SceneManager.LoadScene("ChP12-Boss");
                break;
        }
    }
}
