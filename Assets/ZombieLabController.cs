using UnityEngine;
using NewtonVR;

public class ZombieLabController : MonoBehaviour {

    public NVRHand handWithInventory;

    public float attackDistance = 0;

    public Transform zombieWalkTo1;
    public Transform zombieWalkTo2;

    public Zombie freeZombie;

    private bool walkingToPosition1 = false;
    private bool walkingToPosition2 = false;
    private bool walkingToPosition1Called = false;
    private bool walkingToPosition2Called = false;
    void Update () {
        if (freeZombie != null && (handWithInventory.Inputs[NVRButtons.ApplicationMenu].PressDown || Vector3.Distance(freeZombie.transform.position, handWithInventory.transform.position) < attackDistance))
        {
            freeZombie.Attack();
        }

        if (freeZombie != null && Vector3.Distance(freeZombie.transform.position, handWithInventory.transform.position) < attackDistance)
        {
            freeZombie.Attack();
        }
        if (freeZombie != null && freeZombie.transform.position == zombieWalkTo1.position)
        {
            Debug.Log("Zombie reached position 1");
            walkingToPosition2 = true;
            walkingToPosition1 = false;
        }
        else if(freeZombie != null && freeZombie.transform.position == zombieWalkTo2.position)
        {
            Debug.Log("Zombie reached position 2");
            walkingToPosition1 = true;
            walkingToPosition2 = false;
        }
		if(freeZombie != null && !walkingToPosition1Called && walkingToPosition1)
        {
            freeZombie.WalkTo(zombieWalkTo1);
            walkingToPosition1 = true;
            Debug.Log("Zombie walking to pos 1");
            walkingToPosition1Called = true;
            walkingToPosition2Called = false;
        }
        if (freeZombie != null && !walkingToPosition2Called && walkingToPosition2)
        {
            freeZombie.WalkTo(zombieWalkTo2);
            walkingToPosition2 = true;
            Debug.Log("Zombie walking to pos 2");
            walkingToPosition1Called = false;
            walkingToPosition2Called = true;
        }
        if (freeZombie == null)
            Destroy(gameObject);
    }
}
