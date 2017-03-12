using UnityEngine;

public class ZombieLabHintPlayer : MonoBehaviour {

    public AudioSource infectedSound;
    public float SecondsBeforeInfectedSound = 3;
    public AudioSource InjectionHintSound;
    public float SecondsBeforeInjectionHint = 5;

    private float counter;
    private bool wasInfectedSoundPlayed = false;
    private bool wasInjectionHintPlayed = false;
	
	void Update () {
        counter += Time.deltaTime;

        if (counter > SecondsBeforeInfectedSound && !wasInfectedSoundPlayed)
        {
            infectedSound.Play();
            wasInfectedSoundPlayed = true;
        }
        if ( counter > SecondsBeforeInjectionHint && !wasInjectionHintPlayed)
        {
            InjectionHintSound.Play();
            wasInfectedSoundPlayed = true;
        }
	}
}
