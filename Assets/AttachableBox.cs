using UnityEngine;

public class AttachableBox : MonoBehaviour {

    public Transform AttachPoint;

    public bool isAttached = false;

	void Update () {
        if (isAttached)
            transform.position = AttachPoint.transform.position;

    }
}
