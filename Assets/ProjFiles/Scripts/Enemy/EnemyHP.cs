using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private float enemyHP = 50;
    private void Start()
    {
        if (enemyData != null)
        {
            enemyHP = enemyData.enemyHP;
        }

    }
    public void TakeDamage(float damage)
    {
        enemyHP -= damage;
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
