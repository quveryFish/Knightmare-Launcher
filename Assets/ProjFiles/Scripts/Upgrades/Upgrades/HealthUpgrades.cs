using UnityEngine;

public class HealthUpgrades : MonoBehaviour
{
    private PlayerHP maxHealth;
    private ExpManager exp;


    private void Start()
    {
        maxHealth = PlayerHP.Instance;
        exp = ExpManager.Instance;
    }
    public void MaxHPUpgrade()
    {
        maxHealth.AddMaxHP(50);
        maxHealth.SetMaxHP();
        Debug.Log("Max HP upgraded by 50");
        UpgradesUiManager.Instance.CloseUI();
        //UpgradesUiManager.Instance.isUpgPressed = true;
    }

    public void ExpUpgrade()
    {
        exp.AddExpAddingCount();
        Debug.Log("Exp drop boosted");
        UpgradesUiManager.Instance.CloseUI();
        //UpgradesUiManager.Instance.isUpgPressed = true;
    }
}
