using UnityEngine;

public class EndWave : MonoBehaviour
{
    [SerializeField] private GameObject waveUI;
    private void Update()
    {
        if ( EnemySpawn.Instance.GetNoEnemies())
        {

            waveUI.SetActive(true);

            Debug.Log("Wave Ended!");
            EnemySpawn.Instance.SetNoEnemiesBack();
        }
        if (EnemySpawn.Instance.newWaveStarted == true)
        {
            waveUI.SetActive(false);
        }
    }
}
