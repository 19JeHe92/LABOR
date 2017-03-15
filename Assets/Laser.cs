using UnityEngine;
using NewtonVR;

public class Laser : MonoBehaviour
{
    public HealthBarController playerhealth;
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NVRHead>())
        {
            playerhealth.decreaseHealth(damage);
        }
    }
}
