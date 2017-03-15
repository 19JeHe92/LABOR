using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

public class FinalBattleController : MonoBehaviour {

    public Transform player;
    public HealthBarController playerHealth;
    
    public FinalBoss boss;
    public GameObject zombiePrefab;
    public float secondsBeforeStart = 3f;
    public float talkDuration = 5f;
    public float secondsBeforeFirstRoundOfZombies = 20f;
    public float secondsBossFirstAttack = 3;

    public Transform ZombieSpawningPosition1;
    public Transform ZombieSpawningPosition2;
    public Transform ZombieSpawningPosition3;
    public Transform ZombieSpawningPosition4;

    private float timer = 0;
    private bool isStarted = false;
    private bool firstRoundStarted = false;
    private bool secondRoundStarted = false;
    private bool firstRoundComplete = false;

    private Zombie zombie1;
    private Zombie zombie2;
    private Zombie zombie3;
    private Zombie zombie4;
    private Zombie zombie5;
    private Zombie zombie6;

    private bool complete = false;

    void Awake()
    {
        boss.playerHealth = playerHealth;
    }

    void Update ()
    {

        if (boss == null && !complete)
        {
            complete = true;
            Debug.Log("GameComplete");
            SceneManager.LoadScene("StudentRoom");
        }
        timer += Time.deltaTime;
        if(!isStarted && timer > secondsBeforeStart)
        {
            isStarted = true;
            StartBattle();
            timer = 0f;
        }
        if (timer > secondsBeforeFirstRoundOfZombies)
        {
            boss.Shout();
            SpawnFirstRoundZombies();
        }
        if (firstRoundStarted && zombie1 == null && zombie2 == null && !firstRoundComplete)
        {
            firstRoundComplete = true;
            
            boss.AttackPlayerAndGoBackAfterSeconds(player, secondsBossFirstAttack);
        }
        if (secondRoundStarted && zombie2 == null && zombie3 == null && !secondRoundComplete)
        {
            secondRoundComplete = true;
            firstRoundComplete = true;
            boss.pl
            boss.AttackPlayerUntilDead(player);
        }
    }

    private void SpawnFirstRoundZombies()
    {
        GameObject zombie1 = Instantiate(zombiePrefab, ZombieSpawningPosition1);
        GameObject zombie2 = Instantiate(zombiePrefab, ZombieSpawningPosition2);
        //TODO make zombies attack hte player
        firstRoundStarted = true;
    }

    private void SpawnSecondRoundZombies()
    {
        GameObject zombie3 = Instantiate(zombiePrefab, ZombieSpawningPosition1);
        GameObject zombie4 = Instantiate(zombiePrefab, ZombieSpawningPosition2);
        GameObject zombie5 = Instantiate(zombiePrefab, ZombieSpawningPosition3);
        GameObject zombie6 = Instantiate(zombiePrefab, ZombieSpawningPosition4);
        //TODO make zombies attack hte player
        secondRoundStarted = true;
    }

    private void StartBattle()
    {
        boss.Talk();
        boss.TurnAroundAfter(talkDuration);
    }
}
