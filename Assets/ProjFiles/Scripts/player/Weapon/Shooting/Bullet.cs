using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private ExplosionData explosionsData;

    private void Update()
    {
        BulletLife();
    }

    private void BulletLife()
    {
        bulletLifeTime -= Time.deltaTime;
        if (bulletLifeTime < 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionsData.explosionsList[0], gameObject.transform.position, Quaternion.identity);
        collision.gameObject.GetComponent<EnemyOnDeath>()?.OnDeath();
        Destroy(gameObject);
    }
}
