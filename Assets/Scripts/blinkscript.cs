using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkscript : MonoBehaviour {
    public Renderer rend;
    public float duration= 5.0f;
    public int factor = 7;
    public bool interruptor = true;
    //public Transform target; 
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();

        //interruptor = true;
        rend.enabled = true;
        GetComponent<Collider>().enabled = true;


        //rend.enabled = true;
        // if (gameObject.activeInHierarchy)
        //     gameObject.SetActive(false);

        //StartCoroutine(LateCall());
        //gameObject.SetActive(false);
        //StartCoroutine(Example());
    }
	
	// Update is called once per frame
	void Update () {

        

        //StartCoroutine(Example());
        //StartCoroutine(Example());


        bool oddeven = Mathf.FloorToInt(Time.time) % factor == 0;

        rend.enabled = oddeven;
        GetComponent<Collider>().enabled = oddeven;
        



        /* if (interruptor){
             rend.enabled = true;
             StartCoroutine(On());
             interruptor = false;


         }
         if(!interruptor) {

             rend.enabled = false;
             StartCoroutine(Off());
             interruptor = true;

         }*/







        //Destroy(gameObject,1);
        //rend.enabled = (Time.time  <5);

        //gameObject.active = false;
        //yield WaitForSeconds(duration);
        //gameObject.active = true;



        //yield WaitForSeconds(duration);
        //yield return new WaitForSeconds(duration);



    }




    // IEnumerator Example()
    //{


    //foreach (Transform child in this.transform)
    //{
    //        yield return new WaitForSeconds(duration);
    //child.gameObject.SetActive(false);
    //      rend.enabled = true;

    //    yield return new WaitForSeconds(duration);
    //child.gameObject.SetActive(true);
    //  rend.enabled = false;

    //}

    //}


    void OnCollisionEnter(Collision target)
    {
        Debug.Log("Verdeeeeeeeeeee");
        if (target.gameObject.tag.Equals("poop") == true)
        {
            Debug.Log("rooooooojjooooooooooooooooo");

        }

    }





}
