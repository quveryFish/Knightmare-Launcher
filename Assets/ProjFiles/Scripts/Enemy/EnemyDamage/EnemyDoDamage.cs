using UnityEngine;

public class EnemyDoDamage : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    public void DoDamage()
    {
        PlayerHP.Instance.DealDamage(enemyData.enemyDamage * EnemySpawn.Instance.GetEnemyLvlCount());
    }
}
