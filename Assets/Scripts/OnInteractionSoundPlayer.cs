using UnityEngine;
using NewtonVR;

public class OnInteractionSoundPlayer : MonoBehaviour {

    public AudioSource sound;

    private NVRInteractableItem item;
    private bool isPicked = false;

    void Awake()
    {
        item = GetComponent<NVRInteractableItem>();
    }
    void Upade()
    {

        if (!isPicked && item.AttachedHand)
        {
            isPicked = true;
            sound.Play();
        }
        if (!item.AttachedHand)
        {
            isPicked = false;
        }
    }
}
