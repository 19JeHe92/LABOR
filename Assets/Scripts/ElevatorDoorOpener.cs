using UnityEngine;
using NewtonVR;

//Opens the elevators doors if it is enabled and the open button is pressed
public class ElevatorDoorOpener : MonoBehaviour
{
    public NVRButton openButton;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public Transform leftEnd;
    public Transform rightEnd;
    public float openingSpeed;
    public bool isEnabled = false;

    void Update()
    {
        if (isEnabled && openButton.ButtonWasPushed)
        {
            float step = openingSpeed * Time.deltaTime;
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftEnd.position, step);
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightEnd.position, step);
        }
    }
}
