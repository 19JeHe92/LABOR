using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwelfthCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadTwelfthCheckpoint()
    {
        mainController.LoadScene(Checkpoints.Boss);
    }
}
