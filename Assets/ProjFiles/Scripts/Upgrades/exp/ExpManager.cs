using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public static ExpManager Instance;

    [SerializeField] private int maxExp = 100;
    private int currentExp = 0;

    [SerializeField] private Image expBar;
    [SerializeField] private GameObject UpgradeUI;

    private void Update()
    {
        if (currentExp == maxExp)
        {
            UpgradeUI.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ResetExp();
        }
    }
    public void AddExp()
    {
        if (currentExp < maxExp)
        {
            currentExp += 10;
            ShowEXPui();
        }


    }
    public void ResetExp()
    {
        currentExp = 0;
        ShowEXPui();
    }
    private void ShowEXPui()
    {
        expBar.fillAmount = (float)currentExp / maxExp;
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
