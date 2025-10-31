using UnityEngine;

public class EndWave : MonoBehaviour
{
    [SerializeField] private GameObject EndUI;
    private void Update()
    {
        if ( EnemySpawn.Instance.GetNoEnemies())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

            EndUI.SetActive(true);

            PlayerHP.Instance.gameObject.GetComponent<CameraRotation>().enabled = false;
            PlayerHP.Instance.gameObject.GetComponent<Shoot>().enabled = false;
            //Debug.Log("Wave Ended!");
        }
    }
}
