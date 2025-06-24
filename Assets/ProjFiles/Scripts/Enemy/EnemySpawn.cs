using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private Transform listObj;
    [SerializeField] private GameObject enemy;
    private Transform spawnPoint;

    void Start()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawnPoint = spawners[i].transform;
            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity, listObj);
        }

    }
}
