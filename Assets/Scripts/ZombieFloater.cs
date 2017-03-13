using UnityEngine;

public class ZombieFloater : MonoBehaviour {

    public float floatinLimit = 0.5f;
    public float speed = 20;

    private float angle = 0;
    private float degrees = Mathf.PI / 180;

    private Transform initialtransform;


    void Awake()
    {
        initialtransform = transform;
    }

	void Update () {
        angle += speed * Time.deltaTime;
        if (angle > 360)
            angle -= 360;
        transform.position = new Vector3(transform.position.x, floatinLimit * Mathf.Sin(angle * degrees), transform.position.z);
    }
}
