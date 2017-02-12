using UnityEngine;
using NewtonVR;

public class SteamVRControllerAdder : MonoBehaviour {

    private TeleportVive teleporterScript;
    private NVRHand nvrHand;

    //Adds the NVRHand as a controller for the Vive Teleporter
	void Awake () {

        teleporterScript = gameObject.GetComponent<TeleportVive>();
        nvrHand = gameObject.GetComponent<NVRHand>();

        if(teleporterScript != null)
        {
            if (nvrHand != null)
            {
                teleporterScript.Controllers[0] = nvrHand.GetComponent<SteamVR_TrackedObject>();
            }
            else
            {
                Debug.LogError("No NVRHand attached to SteamVRControllerAdder");
            }
        }
        else
        {
            Debug.LogError("No Vive Teleporter attached to SteamVRControllerAdder");
        }
	}
}
