using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private EnemyOnDeath enemyOnDeath;
    private float enemyHP = 50;
    private void Start()
    {
        enemyOnDeath = gameObject.GetComponent<EnemyOnDeath>();
        if (enemyData != null)
        {
            enemyHP = enemyData.enemyHP * EnemySpawn.Instance.GetEnemyLvlCount();
        }

    }
    public void TakeDamage(float damage)
    {
        enemyHP -= damage;
        if (enemyHP <= 0)
        {
            enemyOnDeath.OnDeath();
            Destroy(gameObject);
        }
    }

    public float GetEnemyHP()
    {
        return enemyHP;
    }
    
}
