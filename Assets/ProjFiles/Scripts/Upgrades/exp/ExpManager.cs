using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public static ExpManager Instance;

    [SerializeField] private int maxExp = 100;
    private int currentExp = 0;

    private int addExpCount = 10;

    [SerializeField] private Image expBar;

    private void Update()
    {

        if (currentExp == maxExp)
        {
            UpgradesUiManager.Instance.OpenUI();
            ResetExp();
        }
        SetMaxExp();//Cheat
    }
    public void AddExp(int addexp)
    {
        if (currentExp < maxExp)
        {
            currentExp += addexp;
            ShowEXPui();
        }


    }
    public void ResetExp()
    {
        currentExp = 0;
        maxExp *= 2;
        ShowEXPui();
    }
    private void ShowEXPui()
    {
        expBar.fillAmount = (float)currentExp / maxExp;
    }

    private void SetMaxExp()//Cheat
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            currentExp = maxExp;
            ShowEXPui();
        }
    }

    public int GetAddExpCount()
    {
        return addExpCount;
    }
    public int AddExpAddingCount()
    {
        addExpCount += 40;
        return addExpCount;
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
