using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int enemyHP;
    public int enemyDamage;
    public int enemySpeed;
    public float AttackSpeed;
}
