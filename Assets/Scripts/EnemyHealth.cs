using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public Enemy enemy;
    public EnemyType type;

    private void Awake()
    {
        if (type == EnemyType.Robot)
        {
            enemy = GetComponent<Robot>();
        }
    }

    void Update()
    {
        if (health < 0)
        {
            enemy.Die();
            Debug.Log("haha! you killed an enemy");
        }
    }

    public void decreaseHealth(int amount)
    {
        if (amount > 0)
            health -= amount;
    }
}
