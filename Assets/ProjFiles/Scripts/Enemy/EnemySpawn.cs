using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn Instance;


    [SerializeField] private GameObject[] spawners;
    [SerializeField] private Transform listObj;
    [SerializeField] private List<GameObject> enemys;
    private Transform spawnPoint;
    private float timer;
    [SerializeField] private float timeToSet = 11f;

    private readonly int timeToDecreaseSpawnRate = 3;
    private readonly float spawnDecreasingNum = 0.03f;

    private float timerUpgEnemies;
    private readonly float timeToUpgEnemies = 88f;

    private int enemyLvlCount = 1;
    void Start()
    {
        timerUpgEnemies = timeToUpgEnemies;
        timer = timeToSet;
        ToSpawn();
    }
    private void Update()
    {
        timerUpgEnemies -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeToSet;
            ToSpawn();
        }
        if (timerUpgEnemies <= 0)
        {
            timerUpgEnemies = timeToUpgEnemies;
            enemyLvlCount++;
            Debug.Log("Enemy Level Up! Current Level: " + enemyLvlCount);
        }

    }

    private void ToSpawn()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawnPoint = spawners[i].transform;
            Instantiate(enemys[Random.Range(0, enemys.Count)], spawnPoint.transform.position, Quaternion.identity, listObj);
            if (timeToSet > timeToDecreaseSpawnRate)
            {
                timeToSet -= spawnDecreasingNum;
            }

        }
    }


    public int GetEnemyLvlCount()
    {
        return enemyLvlCount;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
