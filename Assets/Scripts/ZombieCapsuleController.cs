using UnityEngine;
using NewtonVR;

public class ZombieCapsuleController : MonoBehaviour
{
    public NVRHead player;
    public HealthBarController playerHealth;
    public float secondsBeforeRelease = 15f;
    public GameObject floatingZombie;
    public GameObject attackingZombiePrefab;
    public GameObject CapsuleGlas;
    public bool isReleased = false;
    public Transform disablingEndPosition;
    public float disablingspeed = 2;
    public Transform releasedZombiePosition;

    public AudioSource releaseSound;
    public bool isStarted = false;
    private bool disabling;
    private float counter = 0.0f;

    void Update()
    {
        if (isStarted)
        {
            if (!isReleased && !disabling && counter > secondsBeforeRelease)
            {
                ReleaseZombie();
            }
            else
            {
                counter += Time.deltaTime;
            }
            if (floatingZombie && disabling)
            {
                floatingZombie.transform.position = Vector3.MoveTowards(transform.position, disablingEndPosition.position, disablingspeed * Time.deltaTime);
            }
        }
    }

    private void ReleaseZombie()
    {
        Debug.Log("Zombie Released");
        releaseSound.Play();
        isReleased = true;
        Destroy(CapsuleGlas);
        GameObject releasedZombie = Instantiate(attackingZombiePrefab, releasedZombiePosition.position, releasedZombiePosition.rotation);
        Zombie zombie = releasedZombie.GetComponent<Zombie>();
        Debug.Log(" releasedZombie.GetComponent<Zombie>() " + zombie);
        zombie.playerPosition = player.transform;
        zombie.playerHealth = playerHealth;
        zombie.Attack();
        Destroy(floatingZombie);
    }

    public void DisableZombie()
    {
        disabling = true;
    }
}
