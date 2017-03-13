using UnityEngine;
using NewtonVR;

public class Robot : MonoBehaviour, Enemy {

    public float speed = 3.0f;
    public int damage = 20;
    public float secondsBetweenHits = 2;

    public AudioSource runSound;

    private Animator animations;
    private Vector3 target;
    private HealthBarController player;
    private bool run = false;
    private bool attack = false;
    private float timeCounter = 0f;

    void Awake()
    {
        animations = GetComponent<Animator>();
    }
	
	void Update () {
        if (run)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (attack)
        {
            transform.LookAt(target);
            timeCounter += Time.deltaTime;
            if (timeCounter > secondsBetweenHits)
            {
                timeCounter = 0f;
                player.decreaseHealth(damage);
            }
        }
	}

    public void RunTo(Transform playerHeadTransform)
    {
        runSound.loop = true;
        runSound.Play();
        target = new Vector3(playerHeadTransform.position.x, 0, playerHeadTransform.position.z);
        animations.SetTrigger("run");
        run = true;
    }

    public void Attack(HealthBarController playerHealth)
    {
        runSound.Stop();
        player = playerHealth;
        run = false;
        attack = true;
        animations.SetTrigger("attack");
    }

    public void Die()
    {
        runSound.Stop();
        run = false;
        attack = false;
        animations.SetTrigger("Die");
        Destroy(gameObject, 3f);
    }
}
