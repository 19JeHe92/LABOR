using UnityEngine;

public class FirstRobotController : MonoBehaviour
{

    public Transform playerHead;
    public DoorOpener door;
    public float secondsBeforeAttack = 2.0f;

    private bool attack = false;
    private float timer = 0;

    private Robot robot;
    private bool started = false;

    void Update()
    {
        if (!started)
        {
            attack = door.isCardInserted && door.isCorrectCombinationEntered;
            if (attack)
            {
                timer += Time.deltaTime;
                if (timer > secondsBeforeAttack)
                {
                    robot.Run();
                    started = true;
                }
            }
        }
    }
}
