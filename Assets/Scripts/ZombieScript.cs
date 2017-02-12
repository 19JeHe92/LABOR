
using System;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;


public class ZombieScript : MonoBehaviour
{
    //public NVRHead playerHead;

    public float MoveSpeed = 10.0f;// var MoveSpeed = 4;
    public float MaxDist = 10.0f;//var MaxDist = 10;
    public float MinDist = 10.0f;//0.0000001f; //var MinDist = 5;
    private Animator anim;
    public bool walking = false;


    public Transform target;
    Animator animator;
    bool attackAnim;



    void Start()
    {
        attackAnim = false;
        animator = GetComponent<Animator>();

    }

    void Update()
    {

        //if (walking)
        //{
        //    //transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerHead.transform.position.x, 0, playerHead.transform.position.z), MoveSpeed * Time.deltaTime);
        //    transform.Translate(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * MoveSpeed * Time.deltaTime);
        //    animator.SetTrigger("walk");
        //}



        if (walking)
        {
            walking = true;
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, 0, target.transform.position.z), MoveSpeed * Time.deltaTime);
        }

        if (!walking && Vector3.Distance(transform.position, target.position) > MinDist)
        {
            animator.SetTrigger("walk");
            Debug.Log("walk");
            walking = true;

        }
        if (Math.Abs(transform.position.x- target.position.x) <= MinDist && Math.Abs(transform.position.y - target.position.y) <= MinDist && Math.Abs(transform.position.z - target.position.z) <= MinDist )
        {

            walking = false;
            attackAnim = true;
            Debug.Log("attack");
            animator.SetTrigger("attack");

        }

    }

}