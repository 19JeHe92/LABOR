using UnityEngine;

public class DamageAbsorber : MonoBehaviour {

    public int knifeDamage = 60;
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
            if (item.objectType == InventoryObjectType.Knife)
            {
                health.DecreaseHealth(knifeDamage);
                hitSound.Play();
                Debug.Log("Decreased Robots Health by " + knifeDamage);
            }
        }
    }
}
