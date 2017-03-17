using UnityEngine;
using NewtonVR;

//Decreases the players health if the player collides with a laser
public class Laser : MonoBehaviour
{
    public HealthBarController playerhealth;
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NVRHead>())
        {
            playerhealth.DecreaseHealth(damage);
        }
    }
}
