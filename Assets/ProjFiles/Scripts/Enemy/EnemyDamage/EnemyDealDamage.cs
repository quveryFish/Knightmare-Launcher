using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private AudioSource audioSource;
    private Animator animator;

    private float timer = 1.5f;
    private void Start()
    {
        timer = enemyData.AttackSpeed;
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHP>() != null)
        {
            if (timer <= 0)
            {
                animator.SetTrigger("toAttack");
                audioSource.Play();
                timer = enemyData.AttackSpeed;
            }
        }
    }
}
