using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCapsuleController : MonoBehaviour
{

    public float secondsBeforeRelease = 15f;
    public GameObject Zombie;

    private float counter = 0.0f;

    void Update()
    {
        if (counter > secondsBeforeRelease)
        {
            ReleaseZombie();
        }
        else
        {
            counter += Time.deltaTime;
        }
    }

    private void ReleaseZombie()
    {
        //TODO
    }

    public void DisableZombie()
    {
        //TODO
        //Destroy(gameObject);
    }
}
