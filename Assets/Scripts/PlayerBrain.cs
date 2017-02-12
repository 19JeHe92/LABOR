using UnityEngine;

public class PlayerBrain : MonoBehaviour {

    public Transform PlayerHead;
		
	void Update () {
        //transform.position = new Vector3(PlayerHead.position.x, PlayerHead.position.y, PlayerHead.position.z-0.2f);
        //transform.rotation = PlayerHead.rotation;
        transform.position = PlayerHead.position - (PlayerHead.forward*0.2f);

    }
}
