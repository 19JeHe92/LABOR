using UnityEngine;

//Opens the door if the puzzle is solved
//It also disables the big black box behind the door (which is used to block the teleporter if the player walks through the door )
//Once the door is open, the smashing walls (being the next puzzle) is enabled
public class DoorOpenerCHP4 : MonoBehaviour
{
    public PuzzleController puzzle;
    public float openingSpeed = 2f;
    public GameObject bigBlackBox;
    public GameObject smashingWalls;
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
            smashingWalls.active = true;
            opening = true;
            openSound.Play();
            //open the door
        }
        if (opening)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, openingSpeed * Time.deltaTime);
        }
    }
}
