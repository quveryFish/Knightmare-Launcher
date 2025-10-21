using Unity.VisualScripting;
using UnityEngine;

public class EndWave : MonoBehaviour
{
    private float timerToEnd = 120f; // 2 minutes timer
    private void Update()
    {
        timerToEnd -= Time.deltaTime;
        if (timerToEnd <= 0)
        {
            Debug.Log("Wave Ended!");
        }
    }
}
