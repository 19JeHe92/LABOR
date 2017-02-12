
using System.Collections;
using UnityEngine;

public class Scientist : MonoBehaviour {

    private Animator animator;
    public float secondsbeforeTrigger =10;
    public float walkingspeed = 0.02f;
    public Transform End;
	private bool ft = true;

    bool walking = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine("Wait");
	}
	
	// Update is called once per frame
	void Update () {
        if (walking)
        {


            transform.position = Vector3.MoveTowards(transform.position, End.transform.position, 0.2f * Time.deltaTime);
			if (ft)
			{
				Debug.Log("Run");
				//anim.SetTrigger("Turn");
				StartCoroutine("Wait");
				transform.Rotate(new Vector3(0,-20, 0));
				ft = false;
			}
        }
	}

    IEnumerator Wait()
    {
        animator.SetTrigger("StandUp");
        yield return new WaitForSeconds(secondsbeforeTrigger);
        animator.SetBool("Turn", true);
        walking = true;
        yield return new WaitForSeconds(5);
        walking = false;
    }
}
