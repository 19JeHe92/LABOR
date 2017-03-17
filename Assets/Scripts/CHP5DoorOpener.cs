using UnityEngine;

public class CHP5DoorOpener : MonoBehaviour {

    public PressPlate enablerButton;
    public Transform EndPos;
    private Vector3 Initialposition;
    public float openingSpeed = 0.2f;

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
