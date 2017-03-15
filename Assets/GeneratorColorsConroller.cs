using System.Collections;
using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

public class GeneratorColorsConroller : MonoBehaviour {

    public float secondsBeforeLoadNextScene = 3;

    public NVRAttachJoint attachJoint1;
    public NVRAttachJoint attachJoint2;
    public NVRAttachJoint attachJoint3;
    public NVRAttachJoint attachJoint4;

    public GameObject explosion;
    public Transform explosionPosition;

    private bool exploded = false;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!exploded && attachJoint1.AttachedItem.gameObject.tag == "CorrectTube1" && attachJoint2.AttachedItem.gameObject.tag == "CorrectTube2" && attachJoint3.AttachedItem.gameObject.tag == "CorrectTube3" && attachJoint4.AttachedItem.gameObject.tag == "CorrectTube4")
        {
            exploded = true;
            Instantiate(explosion, explosionPosition);
        }
	}

    private IEnumerator LoadSceneAfterSeconds()
    {
        yield return new WaitForSeconds(secondsBeforeLoadNextScene);
        SceneManager.LoadScene("ChP12-Boss");
    }
}
