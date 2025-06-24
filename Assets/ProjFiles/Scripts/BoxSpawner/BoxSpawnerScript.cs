using UnityEngine;

public class BoxSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;

    private float timerToSpawnBox = 10.5f;
    private float time = 10.5f;

    void Update()
    {
        timerToSpawnBox -= Time.deltaTime;
        if (timerToSpawnBox <= 0)
        {
            Instantiate(boxPrefab, gameObject.transform.position, Quaternion.identity);
            timerToSpawnBox = time;
        }
    }
}
