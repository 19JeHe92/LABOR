using UnityEngine;
using NewtonVR;

public class ButtonBrickController : MonoBehaviour {

    public NVRButton button;
    public AudioSource comeOutSound;
    public float speed;
    public Transform endPos;

    private bool comeOut;

	// Update is called once per frame
	void Update () {
        if (!comeOut && button.ButtonIsPushed)
        {
            comeOut = true;
            comeOutSound.Play();
        }
        if (comeOut)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, speed*Time.deltaTime);
        }
	}
}
