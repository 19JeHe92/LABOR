using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleventhCheckpointLoader : MonoBehaviour {

    public StartController mainController;

    public void LoadEleventhCheckpoint()
    {
        mainController.LoadScene(Checkpoints.GeneratorRoom);
    }
}
