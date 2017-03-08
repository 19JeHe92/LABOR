using UnityEngine;

public class TenthCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadTenthCheckpoint()
    {
        mainController.LoadScene(Checkpoints.Floor2);
    }
}
