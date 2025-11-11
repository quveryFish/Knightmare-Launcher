using UnityEngine;

public class EndWave : MonoBehaviour
{
    [SerializeField] private GameObject waveUI;
    [SerializeField] private GameObject Portal;
    private int count = 1;
    private void Update()
    {
        if (EnemySpawn.Instance.GetNoEnemies())
        {
            if (count < 3) // amount of waves
            {
                waveUI.SetActive(true);
            }

            Debug.Log("Wave Ended!");

            EnemySpawn.Instance.SetNoEnemiesBack();
            if (EnemySpawn.Instance.GetEndGame())
            {
                Portal.SetActive(true);
                PlayerPrefs.SetInt("IsWorld2Enabled", 1);
                PlayerPrefs.Save();
            }
            count++;
        }

        if (EnemySpawn.Instance.newWaveStarted == true)
        {
            waveUI.SetActive(false);
        }
    }
}
