using UnityEngine;
using NewtonVR;

//Plays hints in the zombie lab
public class ZombieLabHintPlayer : MonoBehaviour {

    //InfectedSound
    public AudioSource infectedSound;
    public float SecondsBeforeInfectedSound = 3;

    //InjectionHintSound
    public AudioSource InjectionHintSound;
    public float SecondsBeforeInjectionHint = 5;

    //Disable generator hint
    public GameObject freeZombie;
    public AudioSource disableGeneratorSound;

    //Anagrams hint
    public AudioSource anagramHint;
    public Transform generator;
    public NVRHead head;
    public float distanceToAnagrams = 3;
    public AnagramChecker anagramsGame;


    private float counter;
    private bool wasInfectedSoundPlayed = false;
    private bool wasInjectionHintPlayed = false;
    private bool wasAnagramHintPlayed = false;
    private bool wasdisableGeneratorSoundPlayed = false;

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

        if(freeZombie == null && !wasdisableGeneratorSoundPlayed)
        {
            Debug.Log("Playing Generator Sound");
            disableGeneratorSound.Play();
            wasdisableGeneratorSoundPlayed = true;
            anagramsGame.StartGame();
        }
	}

    private bool IsPlayerNearGenerator()
    {
        return Vector3.Distance(generator.position, head.transform.position) < distanceToAnagrams;
    }
}
