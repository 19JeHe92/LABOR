using UnityEngine;

public class RobotMovement : MonoBehaviour
{

    public float walkSpeed = 0.2f;
    public float runSpeed = 0.4f;

    private bool run = false;
    private bool walk = false;
    private Transform target;

    void Update()
    {
        if (run)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        }
        if (walk)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
    }

    public void GoTo(Transform target)
    {
        this.target.position = new Vector3(target.position.x, 0, target.position.z);
        run = false;
        walk = true;
    }

    public void RunTo(Transform target)
    {
        this.target.position = new Vector3(target.position.x, 0, target.position.z);
        run = true;
        walk = false;
    }

    public void Stop()
    {
        run = false;
        walk = false;
    }
}
