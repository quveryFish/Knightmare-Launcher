using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private Transform listObj;
    [SerializeField] private List<GameObject> enemys;
    private Transform spawnPoint;
    private float timer;
    [SerializeField] private float timeToSet = 7.5f;
    void Start()
    {
        timer = timeToSet;
        ToSpawn();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeToSet;
            ToSpawn();
        }

    }

    private void ToSpawn()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawnPoint = spawners[i].transform;
            Instantiate(enemys[Random.Range(0, enemys.Count)], spawnPoint.transform.position, Quaternion.identity, listObj);
        }
    }
}
