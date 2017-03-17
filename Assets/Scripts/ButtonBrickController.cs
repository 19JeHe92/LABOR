using UnityEngine;
using NewtonVR;

//Controles the plate wich comes out of the wall once the button is pressed
public class ButtonBrickController : MonoBehaviour {

    public NVRButton button;
    public AudioSource comeOutSound;
    public float speed;
    public Transform endPos;

    private bool comeOut;

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
