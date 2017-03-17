using UnityEngine;
using NewtonVR;

//Controls the robots guarding the elevator doors
public class GuardingRobotController : MonoBehaviour {

    public float attackDistance = 5;
    public HealthBarController playerHealth;
    public NVRHead head;

    private Robot robot;

    private bool isRunning = false;
    private bool isAttacking = false;

	void Awake () {
        robot = GetComponent<Robot>();
	}
	
	void Update () {
        if (Vector3.Distance(head.transform.position, transform.position) < attackDistance)
        {
            robot.RunTo(head.transform);
            isRunning = true;
            isAttacking = false;
        }
        if (!isAttacking && Vector3.Distance(robot.transform.position, head.transform.position) < attackDistance)
        {
            robot.Attack(playerHealth);
            isAttacking = true;
            isRunning = false;
        }
    }
}
