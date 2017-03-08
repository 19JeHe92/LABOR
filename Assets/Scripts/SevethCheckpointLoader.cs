using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevethCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadSeventhCheckpoint()
    {
        mainController.LoadScene(Checkpoints.RobotFactory);
    }
}
