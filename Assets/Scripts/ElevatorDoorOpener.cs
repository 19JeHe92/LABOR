using UnityEngine;

public class ElevatorDoorOpener : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;
    public Transform leftEnd;
    public Transform rightEnd;
    public float openingSpeed;
    public bool isOpen = false;

    void Update()
    {
        if (isOpen)
        {
            float step = openingSpeed * Time.deltaTime;
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftEnd.position, step);
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightEnd.position, step);
        }
    }
}
