using UnityEngine;

public class SecondCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadSecondCheckpoint()
    {
        mainController.LoadScene(Checkpoints.ZombieLab);
    }
}
