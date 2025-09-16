using UnityEngine;

public class ExplosionBurnUpgrade : MonoBehaviour
{

    public void BurningBulletUpgrade()
    {
        Shoot.Instance.SetBurningAvailable(true);
        Debug.Log("Burning bullet unlocked");
        UpgradesUiManager.Instance.CloseUI();
    }
    public void BurningDurationUpgrade(int addDuration)
    {
        Shoot.Instance.AddBurnDuration(addDuration);
        Debug.Log("Burning duration upgraded to " + Shoot.Instance.GetBurnDuration() + " seconds");
        UpgradesUiManager.Instance.CloseUI();
    }
    public void BurningDamageUpgrade(int addDamage)
    {
        Shoot.Instance.AddBurnDamage(addDamage);
        Debug.Log("Burning damage upgraded to " + Shoot.Instance.GetBurnDamage() + " per second");
        UpgradesUiManager.Instance.CloseUI();
    }
}
