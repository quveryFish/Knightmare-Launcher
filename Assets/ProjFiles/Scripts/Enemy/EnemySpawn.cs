using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn Instance;
    [Header("Wave Data")]
    [SerializeField] private World1WaveData worldWave1Data;
    [SerializeField] private World1WaveData worldWave2Data;
    [SerializeField] private World1WaveData worldWave3Data;


    [Header("Spawner Data")]

    [SerializeField] private GameObject[] spawners;
    [SerializeField] private Transform listObj;
    [SerializeField] private List<GameObject> enemiesPrefs;
    public List<GameObject> spawnedEnemiesList;

    private GameObject lastSpawned;

    private int enemyLvlCount = 1;

    private int waveCount = 1;
    public bool newWaveStarted = false;

    [Header("Spawn Timing")]

    private float timer;
    [SerializeField] private float timeToSet = 11f;

    private readonly int timeToDecreaseSpawnRate = 3;
    private readonly float spawnDecreasingNum = 0.05f;

    private float timerUpgEnemies;
    private readonly float timeToUpgEnemies = 48f;

    [Header("Enemies Amounts")]

    [SerializeField] private int barbsOnWave;
    [SerializeField] private int hoodsOnWave;
    [SerializeField] private int magesOnWave;

    private bool noEnemies = false;

    private bool endGame = false;

    void Start()
    {
        timerUpgEnemies = timeToUpgEnemies;
        timer = timeToSet;

        SetEnemies(waveCount);
        ToSpawn();
    }
    private void Update()
    {
        timerUpgEnemies -= Time.deltaTime;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeToSet;
            if (!endGame)
            {
                ToSpawn();
            }
        }
        if (!newWaveStarted && Input.GetKeyDown(KeyCode.Space))
        {
            timer = 1f;
        }

        UpgradeEnemies();

        if (spawnedEnemiesList.Count == 0 && barbsOnWave + hoodsOnWave + magesOnWave == 0)
        {
            noEnemies = true;
            waveCount++;
            timer = 17f;
            newWaveStarted = false;
            if (waveCount <= 3)
            {
                SetEnemies(waveCount);
            }
            else
            {
                if (endGame == false)
                {
                    Debug.Log("All Waves Completed!");
                    endGame = true;
                }
            }

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
        if (newWaveStarted == false)
        {
            newWaveStarted = true;
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

    private void UpgradeEnemies()
    {

        if (timerUpgEnemies <= 0)
        {
            timerUpgEnemies = timeToUpgEnemies;
            enemyLvlCount++;
            Debug.Log("Enemy Level Up! Current Level: " + enemyLvlCount);
            timerUpgEnemies = timeToUpgEnemies;
        }
    }
    
    private void SetEnemies(int wave)
    {
        switch (wave)
        {
            case 1:
                barbsOnWave = worldWave1Data.amountOfBarbarians;
                hoodsOnWave = worldWave1Data.amountOfHoods;
                magesOnWave = worldWave1Data.amountOfMages;
                break;
            case 2:
                barbsOnWave = worldWave2Data.amountOfBarbarians;
                hoodsOnWave = worldWave2Data.amountOfHoods;
                magesOnWave = worldWave2Data.amountOfMages;
                break;
            case 3:
                barbsOnWave = worldWave3Data.amountOfBarbarians;
                hoodsOnWave = worldWave3Data.amountOfHoods;
                magesOnWave = worldWave3Data.amountOfMages;
                break;
        }

    }


    public bool GetEndGame()
    {
        return endGame;
    } 

    public bool GetNoEnemies()
    {
        return noEnemies;
    }
    public bool SetNoEnemiesBack()
    {
        return noEnemies = false;
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
