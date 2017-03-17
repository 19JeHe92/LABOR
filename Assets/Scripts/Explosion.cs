using System;
using UnityEngine;
using NewtonVR;

//Handles the instantioation and effects of an explosion
public class Explosion : MonoBehaviour {

    public AudioSource explosionSound;
    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float maxLifeTime = 5f;
    public float explosionRadius = 5f;
    public GameObject explosion;
    public float secondsBeforeExplode = 3f;
    public HealthBarController playerHealth;

    private float timeCounter = 0.0f;

    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    //Calculates the damage applied to the Characters which are inside of the range of the explosion
    //The near a Character is to the explosions middle is, the more damage it gets
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 distance = targetPosition - transform.position;
        float explosionDistance = distance.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;

        return Mathf.Max(0f, relativeDistance * maxDamage);
    }

	void Update () {
        timeCounter += Time.deltaTime;
        if(timeCounter > secondsBeforeExplode)
        {
            playerHealth.DecreaseHealth(Convert.ToInt32(CalculateDamage(playerHealth.transform.position)));
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
                if (!targetRigidbody)
                {
                    continue;
                }
                targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

                EnemyHealth enemyHealth = targetRigidbody.GetComponent<EnemyHealth>();
                if (!enemyHealth)
                {
                    continue;
                }
                enemyHealth.DecreaseHealth(Convert.ToInt32(CalculateDamage(targetRigidbody.position)));
            }

            explosionSound.gameObject.transform.parent = null;
            explosionSound.Play();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
