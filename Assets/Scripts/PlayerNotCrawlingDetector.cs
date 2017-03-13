using UnityEngine;
using NewtonVR;

public class PlayerNotCrawlingDetector : MonoBehaviour {

    public HealthBarController playerHealth;
    public int penaltyAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        NVRHead playerHead = other.GetComponent<NVRHead>();
        if (playerHead)
            playerHealth.decreaseHealth(penaltyAmount);
    }

}
