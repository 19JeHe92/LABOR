using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class RoboFactoryArmController : MonoBehaviour {

    bool down =true;
    bool up = false;
    bool back = false;
    bool bdown = false;
    bool bup = false;
    bool forward = false;
    private Animator animator;

    public GameObject wrist;
    public AttachableBox box; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (down)
        {
            StartCoroutine(waitdown());
            Debug.Log("waitdown");

        }

        if (up)
        {
            StartCoroutine(waitup());
            Debug.Log("waitup");
        }

        if (back)
        {
            StartCoroutine(waitback());
            Debug.Log("waitback");
        }

        if (bdown)
        {
            StartCoroutine(waitbdown());
            Debug.Log("waitbdown");
        }

        if (bup)
        {
            StartCoroutine(waitbup());
            Debug.Log("waitbup");
        }

        if (forward)
        {
            StartCoroutine(waitforward());
            Debug.Log("waitforward");
        }

    }
    IEnumerator waitdown()
    {
        yield return new WaitForSeconds(2);
        down = false;
        up = true;
        animator.SetTrigger("up");
        box.isAttached = false;
        //Spawn new box
    }
    IEnumerator waitup()
    {
        yield return new WaitForSeconds(2);
        up = false;
        back = true;
        animator.SetTrigger("back");
    }
    IEnumerator waitback()
    {
        yield return new WaitForSeconds(2);
        back = false;
        bdown = true;
        animator.SetTrigger("bdown");
    }
    IEnumerator waitbdown()
    {
        yield return new WaitForSeconds(3);
        bdown = false;
        bup = true;
        animator.SetTrigger("bup");
        box.isAttached = true;
    }
    IEnumerator waitbup()
    {
        yield return new WaitForSeconds(3);
        bup = false;
        forward = true;
        animator.SetTrigger("forward");
    }
    IEnumerator waitforward()
    {
        yield return new WaitForSeconds(3);
        forward = false;
        down = true;
        animator.SetTrigger("down");

    }

}
