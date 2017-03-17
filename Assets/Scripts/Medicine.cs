using UnityEngine;
using NewtonVR;

//Increases the player healths if the medicine is in the near of the players head
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
            health.IncreaseHealth(inceaseAmount);
            takePillsSound.transform.parent = null;
            Destroy(gameObject);
        }
	}
}
