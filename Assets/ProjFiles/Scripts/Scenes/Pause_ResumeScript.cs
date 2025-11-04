using UnityEngine;

public class Pause_ResumeScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject player;

    private bool isPaused = false;
    private void Start()
    {
        ResumeGame(pauseMenu);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(pauseMenu);
            }
            else
            {
                PauseGame(pauseMenu);
            }
        }
    }
    public void PauseGame(GameObject menuUI)
    {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
        player.GetComponent<CameraRotation>().enabled = false;
        player.GetComponent<Shoot>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }
    public void ResumeGame(GameObject menuUI)
    {
        Time.timeScale = 1f;
        menuUI.SetActive(false);
        player.GetComponent<CameraRotation>().enabled = true;
        player.GetComponent<Shoot>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }
}
