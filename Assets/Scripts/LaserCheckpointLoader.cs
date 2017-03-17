using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

public class LaserCheckpointLoader : MonoBehaviour {

    private NVRAttachPoint attachPoint;

	void Awake()
    {
        attachPoint = GetComponent<NVRAttachPoint>();
    }
	
	void Update () {
        if (attachPoint.IsAttached)
            SceneManager.LoadScene("ChP6-Laser");
    }
}
