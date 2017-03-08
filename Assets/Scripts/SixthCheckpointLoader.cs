using UnityEngine;

public class SixthCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadSixthCheckpoint()
    {
        mainController.LoadScene(Checkpoints.Lasers);
    }
}
