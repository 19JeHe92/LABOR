using System.Collections;
using NewtonVR;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform blockPosition;
    public bool blocked = true;


	
    // Update is called once per frame
    void LateUpdate () {
        if (blocked)
        {
           // GetComponent<NVRHead>().enabled = false;
            transform.position = blockPosition.position;
        }
	}
}
