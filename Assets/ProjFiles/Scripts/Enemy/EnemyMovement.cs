using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int speed = 7;
    
    private GameObject player;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = PlayerHP.Instance.gameObject;
    }

    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 velocity = direction * speed;
        //velocity.y = rb.velocity.y;
        rb.linearVelocity = velocity;
    }
}
