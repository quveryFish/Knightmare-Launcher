using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerMovement playerMovement;

    [SerializeField] private Image dashBar;

    private Vector3 direction;

    private float timer;
    private readonly float timeToDash = 1.5f;
    private bool canDash = false;
    public bool isDashing = false;


    private void Start()
    {
        canDash = false;
        rb = gameObject.GetComponent<Rigidbody>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        
    }
    private void Update()
    {
            timer += Time.deltaTime;
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
        GetDirection(playerMovement.GetVerticalInput(), playerMovement.GetHorizontalInput());
        rb.AddForce(direction * 1000f, ForceMode.Impulse);
        canDash = false;
    }

    private void ShowDashBar()
    {
        dashBar.fillAmount = timer / timeToDash;
    }
}
