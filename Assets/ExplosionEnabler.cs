using UnityEngine;

public class ExplosionEnabler : MonoBehaviour {

    public AudioSource explosionSound;
    public GameObject explosionPrefab;
    public float secondsBeforeExplode = 3.0f;

    private bool explosionAdded  = false;
    private bool counterStarted = false;
    private PickableItem pickable;
    private float counter = 0.0f;

    void Awake()
    {
        pickable = GetComponent<PickableItem>();
    }

    void Update()
    {
        if (!pickable.IsAttached && !counterStarted)
        {
            counterStarted = true;
        }
        if (counterStarted)
        {
            counter += Time.deltaTime;
        }
        if (counter > secondsBeforeExplode && !explosionAdded)
        {
            Explosion explosion = pickable.gameObject.AddComponent<Explosion>();
            explosion.explosionSound = explosionSound;
            explosion.explosion = explosionPrefab;
            explosionAdded = true;
        }
    }
}
