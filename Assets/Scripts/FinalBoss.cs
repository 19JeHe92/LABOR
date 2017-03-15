using System.Collections;
using UnityEngine;

public class FinalBoss : MonoBehaviour//, Enemy
{
    private Animator animator;
    public AudioSource talk;
    public AudioSource shoutSound;
    public AudioSource getHitSound;
    public AudioSource dieSound;

    public float damage = 10f;
    public float SecondsBetweenHits = 2;
    public float hitLimit = 1f;
    private bool isHitting = false;

    public float walkSpeed = 2;
    public float turnSpeed = 0.2f;

    public bool isImmune = true;

    private Transform Target;
    public HealthBarController playerHealth;
    private bool move;
    private bool turn;
    private float degreesTurned;
    private EnemyHealth health;
    private Transform initilalPosition;

    void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        initilalPosition = transform;
    }

    void Update()
    {

        if(!isHitting && Vector3.Distance(Target.position, transform.position) < hitLimit)
        {
            Hit();
        }else if (isHitting && Vector3.Distance(Target.position, transform.position) >= hitLimit)
        {
            isHitting = false;
            WalkTo(Target);
        }

        if (isImmune && health.enabled)
        {
            health.enabled = false;
        }
        else if (!isImmune && !health.enabled)
        {
            health.enabled = true;
        }
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, walkSpeed * Time.deltaTime);
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
        animator.SetTrigger("shout");
        shoutSound.Play();
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
    }

    public void GetHit()
    {
        if (!isImmune)
        {
            animator.SetTrigger("gethit");
            getHitSound.Play();
        }
    }

    public void Die()
    {
        animator.SetTrigger("die");
        dieSound.Play();
        Destroy(gameObject, 3);
    }

    public void Talk()
    {
        talk.Play();
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

    private IEnumerator SetTargetAfterSeconds(Transform target,  float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.Target = target;
    }

}
