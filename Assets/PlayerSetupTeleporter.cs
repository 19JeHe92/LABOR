using UnityEngine;

public class PlayerSetupTeleporter : MonoBehaviour {

    public NewtonVR.NVRPlayer player;
    public Transform setupPosition;

	void Awake () {
        Vector3 offset = player.transform.position - player.Head.transform.position;
        player.transform.position = new Vector3(setupPosition.position.x + offset.x, 0, setupPosition.position.z + offset.z);
    }
	
}
