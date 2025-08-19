using GLTFast.Schema;
using UnityEngine;

public class PlayerAnimManage : MonoBehaviour
{
    private const string ANIM_SHOOT = "Shoot";


    private Animator animator;
    private float timerToShoot = 0.5f;

    private PlayerMovement playerMovement;
    private PlayerDash playerDash;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
        playerDash = gameObject.GetComponentInParent<PlayerDash>();
    }
    private void Update()
    {
        ShootAnim();

        SetRunningAnim();

        DashAnim();
    }

    private void ShootAnim()
    {
        timerToShoot -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (timerToShoot <= 0)
            {
                timerToShoot = 0.5f;
                animator.SetTrigger(ANIM_SHOOT);
            }
        }
    }

    private void DashAnim()
    {
        if (playerDash.isDashing)
        {
            if (playerMovement.GetHorizontalInput() > 0)
            {
                animator.SetTrigger("DashRight");
            }
            else if (playerMovement.GetHorizontalInput() < 0)
            {
                animator.SetTrigger("DashLeft");
            }
            else if (playerMovement.GetVerticalInput() > 0)
            {
                animator.SetTrigger("DashForward");
            }
            else if (playerMovement.GetVerticalInput() < 0)
            {
                animator.SetTrigger("DashBackward");
            }
            playerDash.isDashing = false;
        }
       
    }

    private void SetRunningAnim()
    {
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
