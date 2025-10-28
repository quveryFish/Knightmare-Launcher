using UnityEngine;
using UnityEngine.UI;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerMovement playerMovement;

    [SerializeField] private Image dashBar;

    private Vector3 direction;

    private float timer;
    private float invTimer;
    private readonly float timeToDash = 1.5f;
    private bool canDash = false;
    public bool isDashing = false;

    private int dashPower = 1000;

    public int maxDashPower = 3000;
    public float minTimeToDash = 0.8f;


    private void Start()
    {
        canDash = false;
        rb = gameObject.GetComponent<Rigidbody>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();

    }
    private void Update()
    {
        timer += Time.deltaTime;
        invTimer -= Time.deltaTime;
        if (timer >= timeToDash)
        {
            canDash = true;
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                isDashing = true;

                Dash();
                timer = 0;
            }
        }
        if (invTimer <= 0)
        {
            PlayerHP.Instance.SetInvincible(false);
        }
        ShowDashBar();
    }

    public void GetDirection(float vertical, float horizontal)
    {
        if (horizontal > 0)
        {
            direction = gameObject.transform.right;
        }
        else if (horizontal < 0)
        {
            direction = -gameObject.transform.right;
        }
        else if (vertical > 0)
        {
            direction = gameObject.transform.forward;
        }
        else if (vertical < 0)
        {
            direction = -gameObject.transform.forward;
        }
    }
    private void Dash()
    {
        invTimer = 0.5f;
        PlayerHP.Instance.SetInvincible(true);

        GetDirection(playerMovement.GetVerticalInput(), playerMovement.GetHorizontalInput());
        rb.AddForce(direction * dashPower, ForceMode.Impulse);
        canDash = false;
    }

    private void ShowDashBar()
    {
        dashBar.fillAmount = timer / timeToDash;
    }

    public int GetDashPower()
    {
        return dashPower;
    }

    public float GetTimeToDash()
    {
        return timeToDash;
    }
    public int AddDashPower()
    {
        return dashPower + 500;
    }

    public float ReduceDashTime()
    {
        if (timeToDash >= 1f)
        {
            return timeToDash - 0.2f;
        }
        else 
        {
            return timeToDash;
        }
    }
}
