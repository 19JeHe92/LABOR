using UnityEngine;

public class NinethCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadNinethCheckpoint()
    {
        mainController.LoadScene(Checkpoints.ControlRoom);
    }
}
