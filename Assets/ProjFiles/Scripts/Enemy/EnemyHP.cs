using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private void Start()
    {
        enemyHP = enemyData.enemyHP;
    }
    private float enemyHP = 50;
    public void TakeDamage(float damage)
    {
        enemyHP -= damage;
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
