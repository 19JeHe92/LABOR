using UnityEngine;
using NewtonVR;

//Plays a hint if the player interacts with an object which he might use later
public class HintPlayer : MonoBehaviour {

    public AudioSource hint;
    private NVRInteractableItem item;

    private void Awake()
    {
        item = GetComponent<PickableItem>();
    }

	void Update () {
        if (item.IsAttached && !hint.isPlaying)
        {
            hint.Play();
        }
	}
}
