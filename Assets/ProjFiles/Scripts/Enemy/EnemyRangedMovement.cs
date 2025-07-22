using UnityEngine;

public class EnemyRangedMovement : MonoBehaviour
{

    [SerializeField] private EnemyData enemyData;

    private GameObject player;
    private Rigidbody rb;

    private Vector3 direction;
    private Vector3 velocity;

    private float timer;
    [SerializeField] private float timeToSet = 3f;

    private void Start()
    {
        timer = timeToSet;
        GetDirection();
        rb = GetComponent<Rigidbody>();

        player = PlayerHP.Instance.gameObject;
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GetDirection();
            timer = timeToSet;
        }
        gameObject.transform.LookAt(direction);
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;
    }
    private void GetDirection()
    {
         direction = (new Vector3(Random.Range(-40, 40), 0, Random.Range(-40, 40)) + transform.position).normalized;
         velocity = direction * enemyData.enemySpeed;
    }
}
