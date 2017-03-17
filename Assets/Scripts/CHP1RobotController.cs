using UnityEngine;
using NewtonVR;

//Makes the robot in the first Chackpoint attack once the player opened the door
public class CHP1RobotController : MonoBehaviour {

    public DoorOpener door;
    public NVRHead playerHead;
    public HealthBarController playerHealth;
    public float attackDistance = 1f;

    private Robot robot;
    private bool isRunning = false;
    private bool isAttacking = false;

    void Awake()
    {
        robot = GetComponent<Robot>();
    }
	
	void Update () {
        if (door.isCardInserted && door.isCorrectCombinationEntered && !isRunning)
        {
            robot.RunTo(playerHead.transform);
            isRunning = true;
            isAttacking = false;
        }
        if (!isAttacking && Vector3.Distance(robot.transform.position, playerHead.transform.position) < attackDistance)
        {
            robot.Attack(playerHealth);
            isAttacking = true;
            isRunning = false;
        }
	}
}
