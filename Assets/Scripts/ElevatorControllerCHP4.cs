using UnityEngine;

//Controls the elevator and the hinds and souns to be played.
public class ElevatorControllerCHP4 : MonoBehaviour {

    public float secondsBeforeStart = 1;
    public float secondsBeforeBreakDown = 5;
    public float secondsBeforeHint = 10;
    public float secondsBetweenCoughs = 4;

    public AudioSource elevatorSound;
    public AudioSource breakDownSound;
    public AudioSource hintSound;
    public AudioSource coughSound;
    public Transform smokeposition;
    public GameObject smokePrefab;

    private bool isStarted = false;
    private bool isBroken = false;
    private bool wasHintPlayed = false;
    private bool cough = false;

    private float timer = 0;
    private float coughTimer = 0;

	void Update () {
        timer += Time.deltaTime;
        if(!isStarted && timer > secondsBeforeStart)
        {
            isStarted = true;
            elevatorSound.Play();
        }
        if (!isBroken && timer > secondsBeforeBreakDown)
        {
            isBroken = true;
            breakDownSound.Play();
            ParticleSystem smokeParticles = Instantiate(smokePrefab, smokeposition.position, smokeposition.rotation).GetComponent<ParticleSystem>();
            smokeParticles.transform.Rotate(0, 180, 0);
            smokeParticles.Play();
            smokeParticles.loop = true;
            cough = true;
        }
        if(!wasHintPlayed && timer > secondsBeforeHint)
        {
            wasHintPlayed = true;
            hintSound.Play();
        }
        if (cough)
        {
            coughTimer += Time.deltaTime;
            if (coughTimer > secondsBetweenCoughs)
            {
                coughSound.Play();
                coughTimer = 0;
            }
        }
	}
}
