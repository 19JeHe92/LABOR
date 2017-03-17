using UnityEngine;

public class ZimbieActivatorByLight : MonoBehaviour
{
    public Transform playersHead;
    public HealthBarController playerHealth;

    void FixedUpdate()
    {
        RaycastHit raycastHit;
        Physics.Raycast(transform.position, -Vector3.forward, out raycastHit, 500.0f);
        Debug.DrawRay(transform.position, -Vector3.forward, Color.red);
        if (raycastHit.collider)
        {
           // Debug.Log("FlashlightHits Collider");
            Zombie zombie = raycastHit.collider.gameObject.GetComponent<Zombie>();
            Debug.Log("Zombie; " +zombie); 

            if (zombie)
            {
                Debug.Log("FlashlightHits Zombie");
                zombie.playerPosition = playersHead;
                zombie.playerHealth = playerHealth;
                zombie.Attack();
            }
            if(raycastHit.collider.gameObject.name == "FreeZombie")
                Debug.Log("FlashlightHits Object with name zombie");
        }
    }
}
