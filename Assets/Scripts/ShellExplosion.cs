using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public AudioSource explosionSound;
    public int damage = 30;
    public float maxLifeTime = 10f;
    public GameObject explosion;

    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy)
            enemy.decreaseHealth(damage);
        explosionSound.gameObject.transform.parent = null;
        explosionSound.Play();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
