using UnityEngine;

public class WeaponLightUpgrades : MonoBehaviour
{

    private Shoot damage;

    private void Start()
    {
        damage = Shoot.Instance;
    }
    public void DamageUpgrade()
    {
        damage.AddDamage(15);
        Debug.Log("Damage upgraded by 15");
        UpgradesUiManager.Instance.CloseUI();
        //UpgradesUiManager.Instance.isUpgPressed = true;
    }
    public void ExplosionRadiusUpgrade()
    {
        damage.AddRadiusNum();
        Debug.Log("Explosion radius upgraded");
        UpgradesUiManager.Instance.CloseUI();
        //UpgradesUiManager.Instance.isUpgPressed = true;
    }
    public void AtkSpeedUpgrade()
    {
        damage.SubtractShootingTime(0.05f);
        Debug.Log("Attack speed decreased");
        UpgradesUiManager.Instance.CloseUI();
        //UpgradesUiManager.Instance.isUpgPressed = true;
    }






}
