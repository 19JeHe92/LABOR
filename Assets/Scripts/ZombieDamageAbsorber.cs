using UnityEngine;

public class ZombieDamageAbsorber : MonoBehaviour {

    public int injectionDamage = 120;
    public AudioSource hitSound;

    private EnemyHealth health;

    void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        PickableItem item = other.GetComponent<PickableItem>();
        if (item)
        {
            if (item.objectType == InventoryObjectType.Injection)
            {
                health.decreaseHealth(injectionDamage);
                hitSound.Play();
                Debug.Log("Decreased Zombies Health by " + injectionDamage);
            }
        }
    }
}
