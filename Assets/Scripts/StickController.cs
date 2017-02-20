using NewtonVR;
using UnityEngine;

//We are not using RequireComponent because:
//RequireComponent impies the error "Can't remove NVRHand Script because ... Script depends on it", which causes the game to crash
//[RequireComponent(typeof(NVRHand))]
public class StickController : MonoBehaviour {

    public bool isVisible = false;
    public NVRButtons callStickButton = NVRButtons.Touchpad;
    public GameObject Stick;

    private NVRHand Hand;

    private void Awake()
    {
        Hand = this.GetComponent<NVRHand>();
    }

    private void LateUpdate()
    {
        if (Hand.Inputs[callStickButton].IsPressed == true)
        {
            if (!Stick.active) {
                //Debug.Log("Call the stick!");
                Stick.SetActive(true);
            }
        }
        else if (Stick.active)
        {
                // Debug.Log("Hide the stick!");
                Stick.SetActive(false);
        }

    }
}
