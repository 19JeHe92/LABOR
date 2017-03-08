using UnityEngine;
using NewtonVR;

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
