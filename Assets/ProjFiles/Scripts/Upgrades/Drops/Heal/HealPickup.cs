using UnityEngine;

public class HealPickup : MonoBehaviour
{
    private float timerToDestroy = 6f;
    private void Update()
    {
        timerToDestroy -= Time.deltaTime;
        if (timerToDestroy <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHP>() != null)
        {
            PlayerHP.Instance.AddHP(25);
            Destroy(gameObject);
        }
    }
}
