using UnityEngine;
using NewtonVR;

//This class is the controller of the main menu
public class StartController : MonoBehaviour {

    public NVRAttachPoint Brain;
    //public Fader fadeOutTexture;
    public GameObject checkpointsList;
    
    //this is a workaround
    //if checkpointslist is disabled at the beginning, the raycaster does not work correctly
    //and since we can't open the GraphicRacaster Script we could't solve it otherwise 
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
}
