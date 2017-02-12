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
            GameDataManager.dataManager.LoadGame();
            //If there are no saved checkpoints load the first chene
            if (GameDataManager.dataManager.checkpoints == null)
            {
                GameDataManager.dataManager.checkpoints.Add(Checkpoints.StartRoom);
                GameDataManager.dataManager.playerHealth = 100;
                GameDataManager.dataManager.SaveGame();
                fadeOutTexture.fadeToBlack = true;
                SceneManager.LoadScene("FirstRoom");
            }
            //else let the player choose which checkpoint he want's to load
            else
            {
                checkpointsList.transform.position = checkpointsListPosition.position;
                //show list of checkpoints
                // get selected
                //Load last checkpoint
               
            }
        }
	}

    public void LoadScene(Checkpoints checkpoint)
    {
        switch (checkpoint)
        {
            case Checkpoints.StartRoom:
                SceneManager.LoadScene("FirstRoom");
                break;
            case Checkpoints.Floor1:
                SceneManager.LoadScene("Floor1");
                break;
            case Checkpoints.Morgue:
                SceneManager.LoadScene("Morgue");
                break;
            case Checkpoints.Floor2:
                SceneManager.LoadScene("Floor2");
                break;
            case Checkpoints.Lift:
                SceneManager.LoadScene("Lift");
                break;
                //TODO: Insert all cases
        }
    }
}
