using UnityEngine;
using UnityEngine.AI;

public class EnemyFreeze : MonoBehaviour
{
    public float freezeDuration = 3f; // Duration of the freeze effect
    public bool isFrozen = false;
    private Animator enemyAnim;
    private NavMeshAgent nma;
    private EnemyMovement enemyMovement;
    private EnemyRangedMovement enemyRangedMovement;
    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement == null)
        {
            enemyRangedMovement = GetComponent<EnemyRangedMovement>();
        }
        nma = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (isFrozen)
        {
            Freeze();
            freezeDuration -= Time.deltaTime;
            if (freezeDuration <= 0)
            {
                UnFreeze();
            }
        }
    }

    private void Freeze()
    {
        enemyAnim.speed = 0;
        if (enemyMovement == null)
        {
            enemyRangedMovement.enabled = false;
        }
        else
        {
            enemyMovement.enabled = false;
            nma.enabled = false;
        }
    }

    private void UnFreeze()
    {
        isFrozen = false;
        if (enemyMovement == null)
        {
            enemyRangedMovement.enabled = true;
        }
        else
        {
            nma.enabled = true;
            enemyMovement.enabled = true;
        }

        enemyAnim.speed = 1;
    }
}
