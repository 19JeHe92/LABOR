using System.Collections;
using UnityEngine;

public class FinalBoss : MonoBehaviour, Enemy
{
    private bool firstShout = false;

    private Animator animator;
    public AudioSource talk;
    public AudioSource shoutSound;
    public AudioSource getHitSound;
    public AudioSource dieSound;

    public int damage = 10;
    public float SecondsBetweenHits = 2;
    public float hitLimit = 1f;
    private bool isHitting = false;

    public float walkSpeed = 2;
    public float turnSpeed = 0.2f;

    public bool isImmune = false;

    public Transform Target;
    public HealthBarController playerHealth;
    private bool move;
    private bool turn;
    private float degreesTurned;
    private EnemyHealth health;
    private Transform initilalPosition;
    private bool hastalked = false;
    private bool attack = false;
    private float timeCounter = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        initilalPosition = transform;
    }

    void Update()
    {

        if (!isHitting && Vector3.Distance(Target.position, transform.position) < hitLimit)
        {
            Hit();
            timeCounter += Time.deltaTime;
            if (timeCounter > 2)
            {
                timeCounter = 0f;
                playerHealth.decreaseHealth(damage);
            }
        }
        else if (isHitting && Vector3.Distance(Target.position, transform.position) >= hitLimit)
        {
            isHitting = false;
            WalkTo(Target);
        }

        //if (isImmune && health.enabled)
        //{
        //    health.enabled = false;
        //}
        //else if (!isImmune && !health.enabled)
        //{
        //    health.enabled = true;
        //}
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, transform.position.y, Target.position.z), walkSpeed * Time.deltaTime);
            transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
        }
        if (turn)
        {
            Vector3 to = new Vector3(0, 180, 0);
            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
            }
            else
            {
                transform.eulerAngles = to;
                turn = false;
            }
        }
    }

    public void TurnAroundAfter(float seconds)
    {
        StartCoroutine(WaitAndTurn(seconds));
    }

    public void Idle()
    {
        animator.SetTrigger("idle");
    }

    public void Shout()
    {
        if (!firstShout)
        {
            animator.SetTrigger("shout");
            shoutSound.Play();
            firstShout = true;
        }
    }

    public void Hit()
    {
        animator.SetTrigger("attack");
        isHitting = true;
    }

    public void WalkTo(Transform to)
    {
        Target = to;
        animator.SetTrigger("walk");
        move = true;
    }

    public void GetHit()
    {
        //if (!isImmune)
        //{
            animator.SetTrigger("gethit");
            getHitSound.Play();
        //}
    }

    public void Die()
    {
        animator.SetTrigger("die");
        dieSound.Play();
        Destroy(gameObject, 3);
    }

    public void Talk()
    {
        if (!hastalked)
        {
            talk.Play();
            hastalked = true;
        }
    }

    private IEnumerator WaitAndTurn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        turn = true;
    }

    public void AttackPlayerAndGoBackAfterSeconds(Transform player, float seconds)
    {
        WalkTo(player);
        StartCoroutine(SetTargetAfterSeconds(initilalPosition, seconds));
    }

    private IEnumerator SetTargetAfterSeconds(Transform target, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.Target = target;
    }

    public void AttackPlayerUntilDead(Transform player)
    {
        WalkTo(player);
        //if (!attack)
        //{
        //    attack = true;
        //    move = true;
        //}
    }
}
