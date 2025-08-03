using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private float timeToDestoy = 0.15f;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyHP>()?.TakeDamage(10);
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
