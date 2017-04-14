using UnityEngine;

public class Robot : MonoBehaviour, Enemy
{

    public int damage = 20;
    public float secondsBetweenHits = 2.0f;
    public float attackDistance = 1.0f;
    public float startKickingDistance = 0.2f;

    public HealthBarController playerHealth;
    public GameObject player;
    public AudioSource runSound;
    public TeleporterDisabler disabler;

    private Animator animations;
    private Vector3 target;
    private bool hitting = false;
    private bool running = false;
    private float timeCounter = 0f;
    private RobotMovement robotMovement;

    void Awake()
    {
        animations = GetComponent<Animator>();
        robotMovement = GetComponent<RobotMovement>();
    }

    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, playerHealth.transform.position) < attackDistance)
        {
            if (!running && !hitting)
            {
                Run();
            }
            else if (Vector3.Distance(gameObject.transform.position, playerHealth.gameObject.transform.position) < startKickingDistance && !hitting)
            {
                Attack();
            }
            else
            {
                Run();
            }
        }

        if (hitting)
        {
            transform.LookAt(target);
            timeCounter += Time.deltaTime;
            if (timeCounter > secondsBetweenHits)
            {
                timeCounter = 0f;
                playerHealth.DecreaseHealth(damage);
            }
        }
    }

    public void Run()
    {
        robotMovement.RunTo(player.transform);

        disabler = player.GetComponent<TeleporterDisabler>();
        disabler.isAttacked = true;

        runSound.loop = true;
        runSound.Play();

        animations.SetBool("run", true);

        running = true;
        hitting = false;
    }

    public void Attack()
    {
        runSound.Stop();
        animations.SetBool("kick", true);

        running = false;
        hitting = true;
    }

    public void Die()
    {
        disabler.isAttacked = false;
        runSound.Stop();
        hitting = false;
        animations.SetBool("die", true);
    }

    public void GetHit()
    {
        animations.SetBool("gethit", true);
    }
}
