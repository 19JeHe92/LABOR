using System.Collections;
using UnityEngine;

public class CapsuleController : MonoBehaviour {

    public float secondsBeforeOpen = 40;
    public float speed = 0.2f;
    public bool opening = false;
    public Transform up;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(secondsBeforeOpen);
        opening = true;
    }

	// Use this for initialization
	void Awake () {
        StartCoroutine("Wait");
	}
	
	// Update is called once per frame
	void Update () {
        if (opening)
        {
            transform.position = Vector3.MoveTowards(transform.position, up.transform.position, speed * Time.deltaTime);
        }
        if (transform.position == up.position)
            opening = false;
	}
}
