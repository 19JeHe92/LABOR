using UnityEngine;
using NewtonVR;

public class HintChecker : MonoBehaviour {

    public NVRInteractableItem hint1;
    public NVRInteractableItem hint2;
    public NVRInteractableItem hint3;

    public AudioSource hintSound;

    private bool hintSoundPlayed = false;

    void Update()
    {
        if(isPlayerInteractingWithHint() && !hintSoundPlayed)
        {
            hintSound.Play();
            hintSoundPlayed = true;
        }
    }

    private bool isPlayerInteractingWithHint()
    {
        return hint1.IsAttached || hint2.IsAttached || hint3.IsAttached;
    }
}
