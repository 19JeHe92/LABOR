using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    public GameObject gameObj;
    // Use this for initialization
    public float speed = 0.9F;
    public float rotatex = 0f;
    public float rotatey = 0.5f;
    public float rotatez = 0.5f;
    public int changedirectionx = -1;
    public int changedirectiony = 1;
    public int changedirectionz = -1;
    // make the object invisible
   //renderer.enabled = false;
    // make the object visible
    //renderer.enabled = true;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate the object around its local X axis at 1 degree per second
        //transform.Rotate(Vector3.right , speed*Time.deltaTime*30);



        gameObj.SetActive(true);
        //yield return new WaitForSeconds(delay);
        //go.SetActive(false);


        transform.Rotate(changedirectionx*speed*rotatex, changedirectiony*speed*rotatey, changedirectionz*speed *rotatez);
        // ...also rotate around the World's Y axis
        //transform.Rotate(Vector3.down * Time.deltaTime*10);
        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }
    
}
