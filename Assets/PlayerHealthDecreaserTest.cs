using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class PlayerHealthDecreaserTest : MonoBehaviour {

    private NVRButton button;
    public HealthBarController health;
	// Use this for initialization
	void Awake () {
        button = GetComponent<NVRButton>();
	}
	
	// Update is called once per frame
	void Update () {
        if (button.ButtonDown)
        {
            health.decreaseHealth(10);
        }
	}
}
