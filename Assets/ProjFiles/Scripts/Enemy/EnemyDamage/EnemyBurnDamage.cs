using System.Collections.Generic;
using UnityEngine;

public class EnemyBurnDamage : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private Material burnMat;
    private bool isBurning = false;
    private float burnCD = 0f;
    private float burnDuration = 5f;
    private int burnDamage = 3;

    private float timeToChangeColour = 0.5f;
    private float timer = 0;
    private bool isBurnColour = false;

    private List<Material> originalMats = new List<Material>();

    EnemyHP enemyHP;
    private void Start()
    {
        foreach (SkinnedMeshRenderer r in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            originalMats.AddRange(r.materials);
        }
        enemyHP = GetComponent<EnemyHP>();
        fireEffect.Stop();
    }
    private void Update()
    {
        if (isBurning && enemyHP.GetEnemyHP() > 0)
        {
            fireEffect.Play();
            ChangeColours();
            burnDuration -= Time.deltaTime;
            burnCD -= Time.deltaTime;
            if (burnDuration <= 0f)
            {
                isBurning = false;
                fireEffect.Stop();
                int i = 0;
                foreach (SkinnedMeshRenderer r in GetComponentsInChildren<SkinnedMeshRenderer>())
                {
                    r.material = originalMats[i];
                    i++;
                }
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

    private void ChangeColours()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (isBurnColour)
            {
                int i = 0;
                foreach (SkinnedMeshRenderer r in GetComponentsInChildren<SkinnedMeshRenderer>())
                {
                    r.material = originalMats[i];
                    i++;
                }
            }
            else
            {
                foreach (SkinnedMeshRenderer r in GetComponentsInChildren<SkinnedMeshRenderer>())
                {
                    r.material = burnMat;
                }
            }
            isBurnColour = !isBurnColour;
            timer = timeToChangeColour;
        }

    }
    
}
