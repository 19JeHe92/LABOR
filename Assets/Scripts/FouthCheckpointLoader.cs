using UnityEngine;

public class FouthCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadFourthCheckpoint()
    {
        mainController.LoadScene(Checkpoints.Smoke);
    }
}
