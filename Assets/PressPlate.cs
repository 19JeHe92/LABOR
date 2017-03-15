using UnityEngine;
using NewtonVR;

public class PressPlate : MonoBehaviour
{

    public float pressDownDistance = 0.3f;
    public bool isPressedByBox = false;
    public bool isPressedByHead = false;
    public NVRHead player;
    public AudioSource pressDownSound;
    public AudioSource releaseSound;

    private float moveDownSpeed = 0.2f;

    private Vector3 initialPosition;
    private Vector3 downPosition;

    private bool wasPressDownSoundPlayed = false;
    private bool wasRelesedSoundPlayed = true;

    void Start()
    {
        initialPosition = transform.position;
        downPosition = new Vector3(transform.position.x, transform.position.y - pressDownDistance, transform.position.z);
    }

    void Update()
    {
        if (isPressedByBox || isPressedByHead)
        {
            transform.position = Vector3.MoveTowards(transform.position, downPosition, moveDownSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveDownSpeed * Time.deltaTime);
        }
        RaycastHit raycastHit;
        Physics.Raycast(initialPosition, Vector3.up, out raycastHit, 100.0f);
        //Debug.DrawLine(transform.position, -Vector3.up);
        if (raycastHit.collider && raycastHit.collider.gameObject.GetComponent<NVRHead>())
        {
            isPressedByHead = true;
            if (!wasPressDownSoundPlayed)
            {
                pressDownSound.Play();
                wasPressDownSoundPlayed = true;
                wasRelesedSoundPlayed = false;
            }
        }
        else
        {
            isPressedByHead = false;
            if (!wasRelesedSoundPlayed)
            {
                releaseSound.Play();
                wasPressDownSoundPlayed = false;
                wasRelesedSoundPlayed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            pressDownSound.Play();
            isPressedByBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Box")
        {
            isPressedByBox = false;
            releaseSound.Play();
        }
    }
}
