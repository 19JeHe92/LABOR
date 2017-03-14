using UnityEngine;
using NewtonVR;

public class ZombieCapsuleController : MonoBehaviour
{
    public NVRHead player;
    public float secondsBeforeRelease = 15f;
    public GameObject floatingZombie;
    public GameObject attackingZombiePrefab;
    public GameObject CapsuleGlas;
    public bool isReleased = false;
    public Transform disablingEndPosition;
    public float disblingspeed = 2;

    public audioSource releaseSound;

    private bool disabling;
    private float counter = 0.0f;

    void Update()
    {
        if (!isReleased && !disabling && counter > secondsBeforeRelease)
        {
            ReleaseZombie();
        }
        else
        {
            counter += Time.deltaTime;
        }
        if (disabling)
        {
            floatingZombie.transform.position = Vector3.MoveTowards(transform.position, disablingEndPosition.position, disblingspeed*Time.delstaTime);
        }
    }

    private void ReleaseZombie()
    {
        releaseSound.Play();
        isReleased = true;
        Destroy(CapsuleGlas);
        GameObject releasedZombie = Instatiate(attackingZombiePrefab, floatingZombie.transform);
        Zombie zombie = releasedZombie.GetComponent<Zombie>();
        zombie.attack(player);
        Destroy(floatingZombie);
    }

    public void DisableZombie()
    {
        disabling = true;
    }
}
