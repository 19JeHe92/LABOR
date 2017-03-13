using UnityEngine;
using NewtonVR;

public class ZombieLabHintPlayer : MonoBehaviour {

    public AudioSource infectedSound;
    public float SecondsBeforeInfectedSound = 3;

    public AudioSource InjectionHintSound;
    public float SecondsBeforeInjectionHint = 5;

    public AudioSource anagramHint;
    public Transform generator;
    public NVRHead head;
    public float distanceToAnagrams = 3;

    private float counter;
    private bool wasInfectedSoundPlayed = false;
    private bool wasInjectionHintPlayed = false;
    private bool wasAnagramHintPlayed = false;
	
	void Update () {
        counter += Time.deltaTime;

        if (counter > SecondsBeforeInfectedSound && !wasInfectedSoundPlayed)
        {
            infectedSound.Play();
            wasInfectedSoundPlayed = true;
        }
        if (!wasInjectionHintPlayed && counter > SecondsBeforeInjectionHint)
        {
            Debug.Log("Play Injection hint!");
            InjectionHintSound.Play();
            wasInjectionHintPlayed = true;
        }

        if (IsPlayerNearGenerator() && !wasAnagramHintPlayed)
        {
            anagramHint.Play();
            wasAnagramHintPlayed = true;
        }
	}

    private bool IsPlayerNearGenerator()
    {
        return Vector3.Distance(generator.position, head.transform.position) < distanceToAnagrams;
    }
}
