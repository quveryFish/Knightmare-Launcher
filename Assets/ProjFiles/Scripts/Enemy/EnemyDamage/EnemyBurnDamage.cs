using UnityEngine;

public class EnemyBurnDamage : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireEffect;
    private bool isBurning = false;
    private float burnCD = 0f;
    private float burnDuration = 5f;
    private int burnDamage = 3;

    EnemyHP enemyHP;
    private void Start()
    {
        enemyHP = GetComponent<EnemyHP>();
        fireEffect.Stop();
    }
    private void Update()
    {
        if (isBurning && enemyHP.GetEnemyHP() > 0)
        {
            fireEffect.Play();
            burnDuration -= Time.deltaTime;
            burnCD -= Time.deltaTime;
            if (burnDuration <= 0f)
            {
                isBurning = false;
                fireEffect.Stop();
                burnDuration = 5f;
            }
            if (burnCD <= 0f)
            {
                enemyHP.TakeDamage(burnDamage);
                burnCD = 1f;
            }

        }
    }

    public void SetBurn(bool state,int damage, float duration)
    {
        Debug.Log("Set burn called");
        burnDamage = damage;
        burnDuration = duration;
        isBurning = state;
    }
    
}
