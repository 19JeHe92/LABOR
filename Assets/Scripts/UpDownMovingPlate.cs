using UnityEngine;
using NewtonVR;

public class UpDownMovingPlate : MonoBehaviour
{
    public NVRPlayer player;
    public Transform playerDetectionPosition;
    public Transform downPosition;
    public PressPlate activationPlate;
    public float movingSpeed = 2f;

    private Vector3 upPosition;
    private bool moveUp = false;
    private bool takeMeWithYou = false;
    void Start()
    {
        upPosition = transform.position;
    }

    void Update()
    {
        RaycastHit raycastHit;
        Physics.Raycast(playerDetectionPosition.position, -Vector3.up, out raycastHit, 100.0f);
        if (raycastHit.collider && raycastHit.collider.gameObject.GetComponent<NVRHead>())
        {
            takeMeWithYou = true;
        }
        else
        {
            takeMeWithYou = false;
        }
        if (activationPlate.isPressedByBox || activationPlate.isPressedByHead)
        {
            if (transform.position == upPosition)
            {
                moveUp = false;
            }
            else if (transform.position == downPosition.position)
            {
                moveUp = true;
            }
            if (moveUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, upPosition, movingSpeed * Time.deltaTime);
                if (takeMeWithYou)
                    player.transform.Translate(Vector3.up * Time.deltaTime * movingSpeed);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, downPosition.position, movingSpeed * Time.deltaTime);
                if (takeMeWithYou)
                    player.transform.Translate(Vector3.down * Time.deltaTime * movingSpeed);
            }
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, downPosition.position, movingSpeed * Time.deltaTime);
    }
}
