using UnityEngine;

//Keeps the players brain in his head
public class PlayerBrain : MonoBehaviour {

    public Transform PlayerHead;
		
	void Update () {
        transform.position = PlayerHead.position - (PlayerHead.forward*0.2f);

    }
}
