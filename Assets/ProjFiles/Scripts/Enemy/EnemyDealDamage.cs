using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{
    private float timer = 1.5f;
    private void Update()
    {
        timer -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (timer <= 0)
        {
            PlayerHP.Instance.DealDamage(10);
            timer = 1.5f;
        }

    }
}
