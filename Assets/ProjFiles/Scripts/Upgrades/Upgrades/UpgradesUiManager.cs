using UnityEngine;

public class UpgradesUiManager : MonoBehaviour
{
    public static UpgradesUiManager Instance;

    [SerializeField] private GameObject UI;

    public bool isUpgPressed = false;
    public void CloseUI()
    {
        UI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OpenUI()
    {
        UI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
