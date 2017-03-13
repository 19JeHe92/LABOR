using UnityEngine;

public class RobotDamageAbsorber : MonoBehaviour {

    private EnemyHealth health;
    public int knifeDamage = 60;

    void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }

	void OnTriggerEnter(Collider other)
    {
        PickableItem item = other.GetComponent<PickableItem>();
        if (item)
        {
            if(item.objectType == InventoryObjectType.Knife)
            {
                health.decreaseHealth(knifeDamage);
                Debug.Log("Decreased Robots Health by "+knifeDamage);
            }
        }
    }
}
