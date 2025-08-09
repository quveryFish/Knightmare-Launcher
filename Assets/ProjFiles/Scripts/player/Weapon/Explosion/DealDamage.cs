using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private int damage = 10;
    private float timeToDestoy = 0.15f;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyHP>()?.TakeDamage(damage);
    }
    private void Update()
    {
        timeToDestoy -= Time.deltaTime;
        if (timeToDestoy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
