using UnityEngine;

public class Pause_ResumeScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject player;
    private void Start()
    {
        ResumeGame();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                player.GetComponent<CameraRotation>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        player.GetComponent<CameraRotation>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
