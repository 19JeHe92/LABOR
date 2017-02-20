using UnityEngine;

public class FifthCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadFifthCheckpoint()
    {
        mainController.LoadScene(Checkpoints.LightsPuzzle);
    }
}
