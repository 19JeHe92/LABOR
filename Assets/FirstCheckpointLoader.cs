using UnityEngine;

public class FirstCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadFirstCheckpoint()
    {
        mainController.LoadScene(Checkpoints.Floor1);
    }
}
