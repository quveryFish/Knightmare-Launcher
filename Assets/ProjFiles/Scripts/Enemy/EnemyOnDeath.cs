using System.Collections.Generic;
using UnityEngine;

public class EnemyOnDeath : MonoBehaviour
{
    [SerializeField] private List<GameObject> lootDrops;

    [SerializeField] private GameObject spawnPoint;
    private void OnDestroy()
    {
        Instantiate(lootDrops[Random.Range(0, lootDrops.Count)], spawnPoint.transform.position, Quaternion.identity);
    }
}
