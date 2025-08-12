using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public static PlayerHP Instance;

    [SerializeField] private int maxHP = 200;

    [SerializeField] private Text healthText;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private Image hpBar;

    private int currentHP = 100;

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
    private void Start()
    {
        currentHP = maxHP;
        loseUI.SetActive(false);
        ShowHPui();
    }
    public void DealDamage(int damage)
    {
        if (currentHP > 0)
        {
            currentHP -= damage;
            ShowHPui();
        }
        if (currentHP <= 0)
        {
            currentHP = 0;
            loseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }
    public void AddHP(int amount)
    {
        if (currentHP < maxHP)
        {
            currentHP += amount;
            if (currentHP > maxHP)
            {
                currentHP = maxHP;
            }
            ShowHPui();
        }
    }
    private void ShowHPui()
    {
        healthText.text = "Health: " + currentHP;
        hpBar.fillAmount = (float)currentHP / maxHP;
    }

    public void SetMaxHP()
    {
        currentHP = maxHP;
        ShowHPui();
    }

    public int AddMaxHP(int addmaxHP)
    {
        maxHP += addmaxHP;
        ShowHPui();
        return maxHP;
    }
}
