using UnityEngine;

//Opens one side of the door is the attached PressPlate has been pressed
public class CHP5DoorOpener : MonoBehaviour {

    public PressPlate enablerButton;
    public Transform EndPos;
    public float openingSpeed = 0.2f;

    private Vector3 Initialposition;
    private bool opening = false;

    void Start () {
        Initialposition = transform.position;
	}
	
	void Update () {
        if (enablerButton.isPressedByBox || enablerButton.isPressedByHead)
        {
            opening = true;
        }
        else opening = false;
        if (opening)
            transform.position = Vector3.MoveTowards(transform.position, EndPos.position, openingSpeed*Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, Initialposition, openingSpeed * Time.deltaTime);
    }
}
