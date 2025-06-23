using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public static PlayerHP Instance;

    private int HP = 100;

    [SerializeField] private Text healthText;
    [SerializeField] private GameObject loseUI;
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
        loseUI.SetActive(false);
    }
    public void DealDamage(int damage)
    {
        if (HP > 0)
        {
            HP -= damage;
            healthText.text = "Health: " + HP;
        }
        else
        {
            HP = 0;
            loseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }
}
