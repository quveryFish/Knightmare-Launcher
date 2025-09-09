using UnityEngine;
using UnityEngine.Audio;

public class EnemyDealDamage : MonoBehaviour
{

    private AudioSource audioSource;
    private Animator animator;

    private float timer = 1.5f;
    private void Start()
    {
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
                timer = 1.5f;
            }
        }
    }
}
