using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadEightCheckpoint()
    {
        mainController.LoadScene(Checkpoints.Height);
    }
}
