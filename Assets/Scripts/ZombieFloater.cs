using UnityEngine;

//Moves a zombie up and down slowly
public class ZombieFloater : MonoBehaviour {

    public float floatinLimit = 0.5f;
    public float speed = 20;

    private float angle = 0;
    private float degrees = Mathf.PI / 180;

    private Vector3 initialtransform;
    private bool moveUp = true;

    void Awake()
    {
        initialtransform = transform.position;
    }

	void Update () {

        if (Mathf.Abs(initialtransform.y - transform.position.y) > floatinLimit)
            moveUp = !moveUp;
        if(moveUp)
            transform.position = new Vector3(transform.position.x, transform.position.y + speed*Time.deltaTime, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }
}
