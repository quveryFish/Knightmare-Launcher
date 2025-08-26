using GLTFast.Schema;
using UnityEngine;

public class PlayerAnimManage : MonoBehaviour
{
    private const string ANIM_SHOOT = "Shoot";

    private const string ANIM_DASH_RIGHT = "DashRight";
    private const string ANIM_DASH_LEFT = "DashLeft";
    private const string ANIM_DASH_FORWARD = "DashForward";
    private const string ANIM_DASH_BACKWARD = "DashBackward";


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
                animator.SetTrigger(ANIM_DASH_RIGHT);
            }
            else if (playerMovement.GetHorizontalInput() < 0)
            {
                animator.SetTrigger(ANIM_DASH_LEFT);
            }
            else if (playerMovement.GetVerticalInput() > 0)
            {
                animator.SetTrigger(ANIM_DASH_FORWARD);
            }
            else if (playerMovement.GetVerticalInput() < 0)
            {
                animator.SetTrigger(ANIM_DASH_BACKWARD);
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
