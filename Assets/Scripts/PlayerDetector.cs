using UnityEngine;
using NewtonVR;
using System.Collections;
using UnityEngine.SceneManagement;

//Loads the next scene if the player is near a point. We user this in the elevators
public class PlayerDetector : MonoBehaviour {

    public NVRHead player;
    public float limit = 3.0f;
    public int secondsBeforeLoad = 3;

    private Vector3 offset;

	void Update ()
    {
        offset = player.transform.position - transform.position;
        if (Mathf.Abs(offset.x) < limit || Mathf.Abs(offset.z) < limit)
        {
            StartCoroutine(LoadSceneAfterSeconds());
        }	
	}

    IEnumerator LoadSceneAfterSeconds()
    {
        yield return new WaitForSeconds(secondsBeforeLoad);
        SceneManager.LoadScene("ChP4-Smoke");
    }
}
