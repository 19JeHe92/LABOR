using System.Collections;
using UnityEngine;

//Controls the capsule in wich the player is held at the beginning of the game
public class CapsuleController : MonoBehaviour {

    public float secondsBeforeOpen = 40;
    public float speed = 0.2f;
    public bool opening = false;
    public Transform up;
    public AudioSource openingSound;
    public PlayerBlocker blocker;

	void Awake () {
        openingSound = GetComponent<AudioSource>();
        StartCoroutine("Wait");
	}
	
    //Wait until the scientist is done with his boring and way too log speech and then release the player
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(secondsBeforeOpen);
        opening = true;
        blocker.blocked = false;
        openingSound.Play();
    }

	void Update () {
        if (opening)
        {
            transform.position = Vector3.MoveTowards(transform.position, up.transform.position, speed * Time.deltaTime);
        }
        if (transform.position == up.position)
            opening = false;
	}
}
