using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerHP>()?.DealDamage(12 + EnemySpawn.Instance.GetEnemyLvlCount());
        Destroy(gameObject);
    }
}
