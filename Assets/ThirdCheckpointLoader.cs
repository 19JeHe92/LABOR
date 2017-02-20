using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadThirdCheckpoint()
    {
        mainController.LoadScene(Checkpoints.RoboFloor);
    }
}
