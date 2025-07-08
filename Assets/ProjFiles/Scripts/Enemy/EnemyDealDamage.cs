using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{

    private Animator animator;

    private float timer = 1.5f;
    private void Start()
    {
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
                PlayerHP playerHP = collision.gameObject.GetComponent<PlayerHP>();
                playerHP.DealDamage(10);
                timer = 1.5f;
            }
        }
    }
}
