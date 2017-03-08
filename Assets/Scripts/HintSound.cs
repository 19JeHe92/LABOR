using UnityEngine;
using NewtonVR;

public class HintSound : MonoBehaviour {

    private AudioSource hintSound;
    private NVRInteractableItem item;
    private bool hintSoundplayed = false;

    public void Awake()
    {
        hintSound = GetComponent<AudioSource>();
        item = GetComponent<NVRInteractableItem>();
    }

    public void Update()
    {
        if(item.IsAttached && !hintSoundplayed)
        {
            hintSound.Play();
            hintSoundplayed = true;
        }
    }
}
