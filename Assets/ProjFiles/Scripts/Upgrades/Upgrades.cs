using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    [SerializeField] private GameObject buttonDamage;
    [SerializeField] private GameObject buttonHealth;
    [SerializeField] private GameObject buttonRadius;
    [SerializeField] private GameObject buttonAtkSpeed;

    private Shoot damage;
    private PlayerHP maxHealth;
    private void Start()
    {

        damage = Shoot.Instance;
        maxHealth = PlayerHP.Instance;
    }

    public void DamageUpgrade()
    {
        damage.AddDamage(15);
        Debug.Log("Damage upgraded by 15");
        DisableButtons();
        CloseUI();
    }
    public void MaxHPUpgrade()
    {
        maxHealth.AddMaxHP(50);
        maxHealth.SetMaxHP();
        Debug.Log("Max HP upgraded by 50");
        DisableButtons();
        CloseUI();
    }
    public void ExplosionRadiusUpgrade()
    {
        damage.AddRadiusNum();
        Debug.Log("Explosion radius upgraded");
        DisableButtons();
        CloseUI();
    }
    public void AtkSpeedUpgrade()
    {
        damage.SubtractShootingTime(0.05f);
        Debug.Log("Attack speed decreased");
        DisableButtons();
        CloseUI();
    }

    private void OnEnable()
    {
        DisableButtons();
        int rnd = Random.Range(1, 5);
        Debug.Log(rnd);

        switch (rnd)
        {
            case 1:
                //Damage
                buttonDamage.SetActive(true);
                break;
            case 2:
                //MaxHP
                buttonHealth.SetActive(true);
                break;
            case 3:
                //Explosion radius
                buttonRadius.SetActive(true);
                break;
            case 4:
                //AttackSpeed
                buttonAtkSpeed.SetActive(true);
                break;
            default:
                Debug.Log("No upgrade available");
                break;
        }

    }
    private void CloseUI()
    {
        UI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void DisableButtons()
    {
        buttonDamage.SetActive(false);
        buttonHealth.SetActive(false);
        buttonRadius.SetActive(false);
        buttonAtkSpeed.SetActive(false);
    }

}
