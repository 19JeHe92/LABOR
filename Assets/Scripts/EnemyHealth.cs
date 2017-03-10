using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    void Update()
    {
        if (health < 0)
        {
            //die
            Debug.Log("haha! you killed an enemy");
        }
    }

    public void decreaseHealth(int amount)
    {
        if (amount > 0)
            health -= amount;
    }
}
