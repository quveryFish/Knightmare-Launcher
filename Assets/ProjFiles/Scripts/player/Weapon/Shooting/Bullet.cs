using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private ExplosionData explosionsData;
    private int explUpgNum;

    private void Start()
    {
        explUpgNum = Shoot.Instance.GetRadiusNum();
    }

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
        if (explUpgNum >= explosionsData.explosionsList.Length)
        {
            explUpgNum = explosionsData.explosionsList.Length -1;
        }
        Instantiate(explosionsData.explosionsList[explUpgNum], gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
