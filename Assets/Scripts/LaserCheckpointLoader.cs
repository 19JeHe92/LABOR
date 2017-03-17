using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

public class LaserCheckpointLoader : MonoBehaviour {

    private NVRAttachPoint attachPoint;

	void Awake()
    {
        attachPoint = GetComponent<NVRAttachPoint>();
    }
	
	// Update is called once per frame
	void Update () {
        if (attachPoint.IsAttached)
            SceneManager.LoadScene("ChP6-Laser");
    }
}
