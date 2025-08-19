using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    [SerializeField] float movementMultiplier = 10f;

    [SerializeField] private Text movetext;

    private Rigidbody rb;

    private Vector3 direction;

    private float horizontalInput;
    private float verticalInput;

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
        movetext.text = $"horizontal: {horizontalInput} " + $"Vertical: {verticalInput} ";
    }

    private void MovePlayer()
    {
        rb.AddForce(direction.normalized * speed * movementMultiplier, ForceMode.Acceleration);
    }

    public float GetHorizontalInput()
    {
        return horizontalInput;
    }
    public float GetVerticalInput()
    {
        return verticalInput;
    }

}
