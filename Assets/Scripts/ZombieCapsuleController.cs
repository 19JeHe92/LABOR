using UnityEngine;

public class ZombieCapsuleController : MonoBehaviour
{

    public float secondsBeforeRelease = 15f;
    public GameObject Zombie;
    public bool isReleased = false;

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
        isReleased = true;
        //TODO
    }

    public void DisableZombie()
    {
        //TODO
        //Destroy(gameObject);
    }
}
