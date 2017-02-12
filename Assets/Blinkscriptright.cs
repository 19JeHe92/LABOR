using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinkscriptright : MonoBehaviour {

    // Use this for initialization
    public bool enbled = true;
    public Renderer rend;
    public int factor = 7;
    //public Transform target;
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //gameObject.GetComponents<BoxCollider>().enabled= true;
        GetComponent<Collider>().enabled = true;


    }
	
	// Update is called once per frame
	void Update () {
        bool oddeven = !(Mathf.FloorToInt(Time.time) % factor == 0);
        rend.enabled = oddeven;
        GetComponent<Collider>().enabled = oddeven;
        //Debug.Log("Verdeeeeeeeeeee");



    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Verdeeeeeeeeeee");
        if (col.gameObject.tag == "poop")
        {
            Destroy(col.gameObject);
            Debug.Log("rooooooojjooooooooooooooooo");

        }

    }
}
