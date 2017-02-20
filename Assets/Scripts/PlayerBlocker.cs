using UnityEngine;
using NewtonVR;

//Block the player at the beginning of tha game 
public class PlayerBlocker: MonoBehaviour {

    public Transform blockPosition;
    public bool blocked = true;
    public NVRPlayer player;

    void LateUpdate () {
        if (blocked)
        {
            Vector3 offset = player.transform.position - player.Head.transform.position;
            player.transform.position = new Vector3(blockPosition.position.x + offset.x, 0, blockPosition.position.z + offset.z);
        }
	}
}
