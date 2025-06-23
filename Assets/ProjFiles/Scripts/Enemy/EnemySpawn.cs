using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    void Start()
    {
        Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
    }
}
