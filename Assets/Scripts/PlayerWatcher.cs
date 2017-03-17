using UnityEngine;

//Makes the object (security camera) look at the player
public class PlayerWatcher : MonoBehaviour {

    public Transform target;

    void Update()
    {
        transform.LookAt(target);
        transform.Rotate(new Vector3(0, 90, 0));
    }
}
