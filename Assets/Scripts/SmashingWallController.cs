using UnityEngine;
using NewtonVR;

public class SmashingWallController : MonoBehaviour
{

    public float speed = 2f;
    public GameObject box;
    public bool isDeactivated = false;
    public Transform endPosLeft;
    public Transform endPosRight;
    public AudioSource smashSound;
    public NVRHead playerHead;
    public HealthBarController health;

    private bool moveToEndPos = true;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        smashSound.Play();
        if (other.tag.Equals("Box"))
        {
            isDeactivated = true;
        }
        else if (other.tag.Equals("MainCamera"))
        {
            health.DecreaseHealth(110);
            Debug.Log("Die Motherfucker!!");
        }
        else moveToEndPos = true;
    }

    void Update()
    {
        if (!isDeactivated)
        {
            //PingPong
            if (moveToEndPos)
                transform.position = Vector3.MoveTowards(transform.position, endPosLeft.position, speed * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, endPosRight.position, speed * Time.deltaTime);
            if (transform.position == endPosLeft.position)
                moveToEndPos = false;

        }
        else
        {
            //Deactivated
            transform.position = Vector3.MoveTowards(transform.position, endPosLeft.position, speed * Time.deltaTime);
        }
    }
}
