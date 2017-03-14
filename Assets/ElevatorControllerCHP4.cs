using UnityEngine;

public class ElevatorControllerCHP4 : MonoBehaviour {

    public float SecondsBeforeStart = 1;
    public float secondsBeforeBreakDown = 5;
    public float secondsBeforeHint = 10;
    public float secondsBetweenCoughs = 4;

    public AudioSource elevatorSound;
    public AudioSource BreakDownSound;
    public AudioSource hintSound;
    public AudioSource coughSound;

    public GameObject smokePrefab;

    private bool isStarted = false;
    private bool isBroken = false;
    private bool wasHintPlayed = false;
    private bool cough = false;

    private float timer = 0;
    private float coughTimer = 0;

	void Update () {
        timer += Time.deltaTime;
        if(!isStarted && timer > SecondsBeforeStart)
        {
            isStarted = true;
            elevatorSound.Play();
        }
        if (!isBroken && timer > secondsBeforeBreakDown)
        {
            isBroken = true;
            BreakDownSound.Play();
            Instantiate(smokePrefab);
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
