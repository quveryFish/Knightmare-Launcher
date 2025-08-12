using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    [SerializeField] float movementMultiplier = 10f;

    private Rigidbody rb;

    private Vector3 direction;

    float horizontalInput;
    float verticalInput;

    //private bool isMoving = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = transform.forward * verticalInput + transform.right * horizontalInput;
    }

    private void MovePlayer()
    {
        rb.AddForce(direction.normalized * speed * movementMultiplier, ForceMode.Acceleration);
    }

}
