using UnityEngine;

//Checks if the needed PressPlates are pressed and shows the SolutionObject if so
public class CHP5SolutionEnabler : MonoBehaviour
{

    public float comingUpSpeed = 2f;
    public PressPlate leftDoorPlate;
    public PressPlate rightDoorPlate;
    public Transform solutionEndPos;
    public GameObject solution;
    public GameObject AttachObject;

    private PressPlate thisPlate;
    private bool solved = false;
    private Transform solutionObjectinitialPos;


    void Start()
    {
        solutionObjectinitialPos = solution.transform;
    }

    void Awake()
    {
        thisPlate = GetComponent<PressPlate>();
    }
    void Update()
    {

        if ((leftDoorPlate.isPressedByBox || leftDoorPlate.isPressedByHead) && (rightDoorPlate.isPressedByBox || rightDoorPlate.isPressedByHead) && (thisPlate.isPressedByBox || thisPlate.isPressedByHead))
        {
            solved = true;
        }
        else
            solved = false;
        if (solved)
        {
            solution.transform.position = Vector3.MoveTowards(solution.transform.position, solutionEndPos.position, comingUpSpeed * Time.deltaTime);
            if (solution.transform.position == solutionEndPos.position)
            {
                AttachObject.transform.parent = null;
                AttachObject.GetComponent<BoxCollider>().enabled = true;
                AttachObject.GetComponent<Rigidbody>().useGravity = true;
                //AttachObject.GetComponent<Rigidbody>().isKinematic = ;
            }
        }
        else
        {
            solution.transform.position = Vector3.MoveTowards(solution.transform.position, solutionObjectinitialPos.position, comingUpSpeed * Time.deltaTime);
        }
    }
}
