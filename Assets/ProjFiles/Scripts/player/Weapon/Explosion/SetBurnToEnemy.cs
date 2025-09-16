using UnityEngine;

public class SetBurnToEnemy : MonoBehaviour
{
    Shoot shoot;
    private void Start()
    {
        shoot = Shoot.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
            EnemyBurnDamage enemyBurnDamage = other.GetComponent<EnemyBurnDamage>();
        if (shoot.GetToBurningAmmoCount() >= 3 && enemyBurnDamage != null && shoot.GetBurningAvailable() ==  true)
        {
            enemyBurnDamage.SetBurn(true, shoot.GetBurnDamage(), shoot.GetBurnDuration());
            Debug.Log("Enemy is burning");
            shoot.ResetToBurningAmmoCount();
        }
        else if (shoot.GetToBurningAmmoCount() >= 3)
        {
            shoot.ResetToBurningAmmoCount();
        }
    }   
}
