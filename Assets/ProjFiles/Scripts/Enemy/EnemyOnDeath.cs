using UnityEngine;

public class EnemyOnDeath : MonoBehaviour
{
    [SerializeField] private GameObject expObj;
    [SerializeField] private GameObject spawnPoint;
    private void OnDestroy()
    {
        Instantiate(expObj, spawnPoint.transform.position, Quaternion.identity);
    }
}
