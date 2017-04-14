using System.Collections;
using UnityEngine;
using NewtonVR;

public class ControlRoomGeneratorController : MonoBehaviour {

    public YellowPuzzle yellowpuzzle;
    public PuzzleController greenpuzzle;
    public RedPuzzle redpuzzle;
//    public PinkPuzzle pinkpuzzle;

    public AudioSource generatorDownSound;
    private bool down = false;

    public NVRButton buttonToNextScene;

    void Update () {
		//if(!down && yellowpuzzle.solved && greenpuzzle.solved && redpuzzle.solved && pinkpuzzle.solved)
  //      {
  //          down = true;
  //          PlaySounds();
  //      }
	}

    private void PlaySounds()
    {
        generatorDownSound.Play();
        StartCoroutine(startAlarm());
    }

    private IEnumerator startAlarm()
    {
        yield return new WaitForSeconds(5);
        buttonToNextScene.enabled = true;
    }
}
