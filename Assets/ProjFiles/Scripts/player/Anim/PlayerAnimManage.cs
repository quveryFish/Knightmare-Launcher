using GLTFast.Schema;
using UnityEngine;

public class PlayerAnimManage : MonoBehaviour
{
    private Animator animator;
    private float timerToShoot = 0.2f;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        timerToShoot -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (timerToShoot <= 0)
            {
                timerToShoot = 0.2f;
                animator.SetTrigger("Shoot");
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isRunning", false);
        }
    }
}
