using UnityEngine;

public class EndWave : MonoBehaviour
{
    [SerializeField] private GameObject waveUI;
    [SerializeField] private GameObject Portal;
    private void Update()
    {
        if ( EnemySpawn.Instance.GetNoEnemies())
        {

            waveUI.SetActive(true);

            Debug.Log("Wave Ended!");
            EnemySpawn.Instance.SetNoEnemiesBack();
            if (EnemySpawn.Instance.GetEndGame())
            {
                Portal.SetActive(true);
            }
        }
        if (EnemySpawn.Instance.newWaveStarted == true)
        {
            waveUI.SetActive(false);
        }
    }
}
