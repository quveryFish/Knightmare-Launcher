using UnityEngine;

public class CollectExp : MonoBehaviour
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
            ExpManager.Instance.AddExp();
            Destroy(gameObject);
        }
    }
}
