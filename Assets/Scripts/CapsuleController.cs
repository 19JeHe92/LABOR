using System.Collections;
using UnityEngine;

public class CapsuleController : MonoBehaviour {

    public float secondsBeforeOpen = 40;
    public float speed = 0.2f;
    public bool opening = false;
    public Transform up;
    public AudioSource openingSound;

	void Awake () {
        openingSound = GetComponent<AudioSource>();
        StartCoroutine("Wait");
	}
	
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(secondsBeforeOpen);
        opening = true;
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
