using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn Instance;
    [Header("Wave Data")]
    [SerializeField] private World1WaveData worldWaveData;


    [Header("Spawner Data")]

    [SerializeField] private GameObject[] spawners;
    [SerializeField] private Transform listObj;
    [SerializeField] private List<GameObject> enemiesPrefs;
    public List<GameObject> spawnedEnemiesList;

    private GameObject lastSpawned;


    [Header("Spawn Timing")]

    private float timer;
    [SerializeField] private float timeToSet = 11f;


    [Header("Enemies Amounts")]

    [SerializeField] private int barbsOnWave;
    [SerializeField] private int hoodsOnWave;
    [SerializeField] private int magesOnWave;

    private bool noEnemies = false;

    private readonly int timeToDecreaseSpawnRate = 3;
    private readonly float spawnDecreasingNum = 0.05f;

    private float timerUpgEnemies;
    private readonly float timeToUpgEnemies = 48f;

    private int enemyLvlCount = 1;
    void Start()
    {
        timerUpgEnemies = timeToUpgEnemies;
        timer = timeToSet;

        barbsOnWave = worldWaveData.amountOfBarbarians;
        hoodsOnWave = worldWaveData.amountOfHoods;
        magesOnWave = worldWaveData.amountOfMages;

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
            timerUpgEnemies = timeToUpgEnemies;
        }
        if (spawnedEnemiesList.Count == 0 && barbsOnWave + hoodsOnWave + magesOnWave == 0)
        {
            noEnemies = true;
        }

    }

    private void ToSpawn()
    {
            for (int i = 0; i < spawners.Length; i++)
            {
                if (barbsOnWave + hoodsOnWave + magesOnWave > 0)
                {
                    Transform spawnPoint = spawners[i].transform;
                    lastSpawned = Instantiate(SelectEnemyToSpawn(), spawnPoint.transform.position, Quaternion.identity, listObj);
                    spawnedEnemiesList.Add(lastSpawned);
                    if (timeToSet > timeToDecreaseSpawnRate)
                    {
                        timeToSet -= spawnDecreasingNum;
                    }

                }
            }
    }
    public int GetEnemyLvlCount()
    {
        return enemyLvlCount;
    }


    private GameObject SelectEnemyToSpawn()
    {
        GameObject enemy;
        int rnd = Random.Range(0, 100+1);
        enemy = null; //Default to nothing
        while (enemy == null)
        {
            if (rnd >=60)
            {
                if (barbsOnWave > 0)
                {
                    enemy = enemiesPrefs[0];
                    barbsOnWave--;
                }
                else
                {
                    rnd = Random.Range(0, 100 + 1);
                }
            }
            else if (rnd < 60 && rnd >= 25)
            {
                if (hoodsOnWave > 0)
                {
                    enemy = enemiesPrefs[1];
                    hoodsOnWave--;
                }
                else
                {
                    rnd = Random.Range(0, 100 + 1);
                }
            }
            else if (rnd < 25)
            {
                if (magesOnWave > 0)
                {
                    enemy = enemiesPrefs[2];
                    magesOnWave--;
                }
                else
                {
                    rnd = Random.Range(0, 100 + 1);
                }
            }
        }

        return enemy;
    }
       
    public bool GetNoEnemies()
    {
        return noEnemies;
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
