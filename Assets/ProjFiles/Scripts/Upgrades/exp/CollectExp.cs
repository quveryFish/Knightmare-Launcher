using UnityEngine;

public class CollectExp : MonoBehaviour
{

    private int addExpCount = 10;
    private float timerToDestroy = 6f;
    private void Start()
    {
        addExpCount = ExpManager.Instance.GetAddExpCount();
    }
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
            ExpManager.Instance.AddExp(addExpCount);
            Destroy(gameObject);
        }
    }
}
