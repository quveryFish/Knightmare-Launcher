using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public static ExpManager Instance;

    [SerializeField] private int maxExp = 100;
    private int currentExp = 0;

    [SerializeField] private Image expBar;

    public bool onMaxExp = false;
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
