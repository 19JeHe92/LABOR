using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAtack : MonoBehaviour {

    public Transform playerPosition;
    public HealthBarController playerHealth;
    public float attackDistance;
    
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(playerPosition.position, transform.position) < attackDistance)
        {
            GetComponent<Zombie>().Attack();
            
        }
	}
}
