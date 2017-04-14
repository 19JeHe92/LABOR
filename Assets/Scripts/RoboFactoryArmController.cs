using System.Collections;
using UnityEngine;
using NewtonVR;

public class RoboFactoryArmController : MonoBehaviour {

    public float delayBetweenRounds = 4;
    public GameObject wrist;
    public GameObject boxPrefab; 
    public Transform boxSpawningPosition;
    public GameObject RobotPrefab;
    public NVRHead player;
    public HealthBarController playerHealth;
    public Transform boxAttachPointPosition;

    private bool down =true;
    private bool up = false;
    private bool forward = false;
    private bool backward = false;
    private bool backDown = false;
    private bool bachUp = false;
    private Animator animator;

  //  public AttachableBox CurrentBox;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (down)
        {
            StartCoroutine(MoveDown());
        }

        if (up)
        {
            StartCoroutine(MoveUp());
        }

        if (backward)
        {
            StartCoroutine(MoveBack());
        }

        if (backDown)
        {
            StartCoroutine(MoveDownBackward());
        }

        if (bachUp)
        {
            StartCoroutine(MoveUpBackward());
        }

        if (forward)
        {
            StartCoroutine(MoveForward());
        }

    }
    IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(2);
        down = false;
        up = true;
        //animator.SetTrigger("up");
        //CurrentBox.isAttached = false;
        //Destroy(CurrentBox);
        //if you have time: instantiate a short life particle sys
        SpawnRobot();
        SpawnNewBox();
    }
    IEnumerator MoveUp()
    {
        yield return new WaitForSeconds(2);
        up = false;
        backward = true;
        animator.SetTrigger("back");
    }
    IEnumerator MoveBack()
    {
        yield return new WaitForSeconds(2);
        backward = false;
        backDown = true;
        animator.SetTrigger("bdown");
    }
    IEnumerator MoveDownBackward()
    {
        yield return new WaitForSeconds(3);
        backDown = false;
        bachUp = true;
        animator.SetTrigger("bup");
      //  CurrentBox.isAttached = true;
    }
    IEnumerator MoveUpBackward()
    {
        yield return new WaitForSeconds(delayBetweenRounds);
        bachUp = false;
        forward = true;
        animator.SetTrigger("forward");
    }
    IEnumerator MoveForward()
    {
        yield return new WaitForSeconds(3);
        forward = false;
        down = true;
        animator.SetTrigger("down");
    }

    private void SpawnRobot()
    {
        //GameObject spawnedRobot = Instantiate(RobotPrefab, CurrentBox.gameObject.transform.position, Quaternion.identity);
        //Robot robot = spawnedRobot.GetComponent<Robot>();
        //robot.RunToAndAttack(player.transform, playerHealth);
    }

    private void SpawnNewBox()
    {
        GameObject spawnedBox = Instantiate(boxPrefab, boxSpawningPosition);
     //   AttachableBox box = spawnedBox.GetComponent<AttachableBox>();
     //   box.AttachPoint = boxAttachPointPosition;
     //   CurrentBox = spawnedBox.GetComponent<AttachableBox>();
    }

}
