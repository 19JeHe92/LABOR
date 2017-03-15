using UnityEngine;

public class ZimbieActivatorByLight : MonoBehaviour
{
    public Transform playersHead;
    public HealthBarController playerHealth;

    void Update()
    {
        RaycastHit raycastHit;
        Physics.Raycast(transform.position, Vector3.forward, out raycastHit, 100.0f);
        //Debug.DrawLine(transform.position, -Vector3.up);
        if (raycastHit.collider)
        {
            Zombie zombie = raycastHit.collider.gameObject.GetComponent<Zombie>();
            if (zombie)
            {
                zombie.playerPosition = playersHead;
                zombie.playerHealth = playerHealth;
                zombie.Attack();
            }
        }
    }
}
