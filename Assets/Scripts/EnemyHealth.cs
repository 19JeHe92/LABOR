using UnityEngine;

//Keeps thack of the enemys health and kills it (with fire) if the health is less that 0
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
        if (type == EnemyType.Zombie)
        {
            enemy = GetComponent<Zombie>();
        }
        if (type == EnemyType.FinalBoss)
        {
            enemy = GetComponent<FinalBoss>();
        }
    }

    void Update()
    {
        if (health < 0)
        {
            enemy.Die();
            //Debug.Log("haha! you killed an enemy");
        }
    }

    public void DecreaseHealth(int amount)
    {
        if (amount > 0)
            health -= amount;
    }
}
