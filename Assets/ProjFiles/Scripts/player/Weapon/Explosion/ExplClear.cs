using UnityEngine;

public class ExplClear : MonoBehaviour
{
    private float timer;
    private float timeToDestroy = 2f;
    private void Start()
    {
        timer = timeToDestroy;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }   
    }
}
