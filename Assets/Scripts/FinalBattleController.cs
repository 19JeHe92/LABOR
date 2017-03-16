using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

public class FinalBattleController : MonoBehaviour
{
    public NVRHead playerPosition;
    public HealthBarController playerhealth;

    public FinalBoss boss;

    public GameObject Zombiepefab;
    public Transform zombie1Pos;
    public Transform zombie2Pos;
    public Transform zombie3Pos;
    public Transform zombie4Pos;
    private Zombie zombie1;
    private Zombie zombie2;
    private Zombie zombie3;
    private Zombie zombie4;
    private bool areZombiesSpawn = false;
    public float secondsBeforeTalkStart = 3;
    public float secondsBeforeTurnAround = 46;
    public float secondsBeforeShout = 50;
    public float secondsBeforeBossAttack = 10;

    private float counter = 0;

    void Update()
    {
        counter += Time.deltaTime;
        if (counter > secondsBeforeTalkStart)
        {
            boss.Talk();
        }
        if (counter > secondsBeforeTurnAround)
        {
            boss.TurnAroundAfter(0);
        }
        if (counter > secondsBeforeShout)
        {
            boss.Shout();
            if (!areZombiesSpawn)
            {
                SpawnZombies();
                areZombiesSpawn = true;
            }
        }
        if (counter > secondsBeforeBossAttack)
            boss.AttackPlayerUntilDead(playerPosition.transform);
        if(areZombiesSpawn && zombie1 == null && zombie2 == null && zombie3 == null && zombie4 == null)
        {
            SceneManager.LoadScene("StudentsRoom");
        }
    }

    private void SpawnZombies()
    {
        Debug.Log("Instantiating zombies");
        zombie1 = Instantiate(Zombiepefab, zombie1Pos.position, zombie1Pos.rotation).GetComponent<Zombie>();
        zombie2 = Instantiate(Zombiepefab, zombie2Pos.position, zombie2Pos.rotation).GetComponent<Zombie>();
        zombie3 = Instantiate(Zombiepefab, zombie3Pos.position, zombie3Pos.rotation).GetComponent<Zombie>();
        zombie4 = Instantiate(Zombiepefab, zombie4Pos.position, zombie4Pos.rotation).GetComponent<Zombie>();
        zombie1.playerHealth = playerhealth;
        zombie1.playerPosition = playerPosition.gameObject.transform;
        zombie1.Attack();
        zombie2.playerHealth = playerhealth;
        zombie2.playerPosition = playerPosition.gameObject.transform;
        zombie2.Attack();
        zombie3.playerHealth = playerhealth;
        zombie3.playerPosition = playerPosition.gameObject.transform;
        zombie3.Attack();
        zombie4.playerHealth = playerhealth;
        zombie4.playerPosition = playerPosition.gameObject.transform;
        zombie4.Attack();
    }
}
