using UnityEngine;
using NewtonVR;

//Decreases the health of the player if he is not crawling
public class PlayerNotCrawlingDetector : MonoBehaviour {

    public HealthBarController playerHealth;
    public int penaltyAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        NVRHead playerHead = other.GetComponent<NVRHead>();
        if (playerHead)
            playerHealth.DecreaseHealth(penaltyAmount);
    }

}
