using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMidR : MonoBehaviour
{

    // Use this for initialization
    public float speed = 0.9F;
    public float rotatex = 0f;
    public float rotatey = 0.2f;
    public float rotatez = 0.4f;
    public int changedirectionx = -1;
    public int changedirectiony = 1;
    public int changedirectionz = -1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
        //transform.Rotate(Vector3.right , speed*Time.deltaTime*30);
        transform.Rotate(changedirectionx * speed * rotatex, changedirectiony * speed * rotatey, changedirectionz * speed * rotatez);
        // ...also rotate around the World's Y axis
        //transform.Rotate(Vector3.down * Time.deltaTime*10);
        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }

}