using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private GameObject childRad;

    private int damage = 10;
    private float timeToDestoyRadius = 0.15f;
    private float timeToDestroyObj = 0.9f;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyHP>()?.TakeDamage(damage);
    }
    private void Start()
    {
        damage = Shoot.Instance.GetDamage();
    }
    private void Update()
    {
        timeToDestroyObj -= Time.deltaTime;
        timeToDestoyRadius -= Time.deltaTime;
        if (timeToDestoyRadius <= 0)
        {
            Destroy(childRad);
        }
        if (timeToDestroyObj <= 0)
        {
            Destroy(gameObject);
        }
    }
}
