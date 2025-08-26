using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private GameObject player;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = PlayerHP.Instance.gameObject;
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 velocity = direction * enemyData.enemySpeed;
        gameObject.transform.LookAt(player.transform.position);
        //velocity.y = rb.velocity.y;
        rb.linearVelocity = velocity;
    }
}
