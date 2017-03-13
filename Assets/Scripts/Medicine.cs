using UnityEngine;
using NewtonVR;

public class Medicine : MonoBehaviour {

    public HealthBarController health;
    public NVRHead head;
    public AudioSource takePillsSound;
    public int inceaseAmount = 30;
    public float headDetected = 1f;
	
	void Update () {
        Vector3 dif = transform.position - head.transform.position;
        var curDistance = dif.sqrMagnitude;
        if (curDistance < headDetected)
        {
            takePillsSound.Play();
            health.increaseHealth(inceaseAmount);
            takePillsSound.transform.parent = null;
            Destroy(gameObject);
        }
	}
}
