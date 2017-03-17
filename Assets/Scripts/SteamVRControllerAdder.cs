using UnityEngine;
using NewtonVR;

//This class is needed to be able to use the Vive teleporter with newtonVR
//It adds SteamVRs physical controllers at runtime
public class SteamVRControllerAdder : MonoBehaviour {

    public NVRHand nvrHand;
    private TeleportVive teleporterScript;

    //Adds one NVRHand as a controller for the Vive Teleporter
	void Start () {

        teleporterScript = gameObject.GetComponent<TeleportVive>();

        if(teleporterScript != null)
        {
            if (nvrHand != null)
            {
                teleporterScript.Controllers = new SteamVR_TrackedObject[1];
                teleporterScript.Controllers[0] = nvrHand.GetComponent<SteamVR_TrackedObject>();
                Debug.Log("Controller added as teleporter");
            }
            else
            {
                Debug.LogError("No NVRHand set in SteamVRControllerAdder");
            }
        }
        else
        {
            Debug.LogError("No Vive Teleporter attached to SteamVRControllerAdder");
        }
	}
}
