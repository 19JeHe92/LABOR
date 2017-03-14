using UnityEngine;

public class DoorOpenerCHP4 : MonoBehaviour
{
    // TODO enable Teleporter
    public PuzzleController puzzle;
    public float OpeningSpeed = 2f;
    public GameObject bigBlackBox;
    public Transform endPos;
    public bool isOpen = false;
    public AudioSource openSound;

    private bool opening;

    void Update()
    {

        if (!isOpen && puzzle.solved)
        {
            isOpen = true;
            bigBlackBox.active = false;
            opening = true;
            openSound.Play();
            //open the door
        }
        if (opening)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, OpeningSpeed * Time.deltaTime);
        }
    }
}
