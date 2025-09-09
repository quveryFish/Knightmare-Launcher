using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyData data;

    private Transform playerTarget;
    private NavMeshAgent agent;
    private void Start()
    {
        playerTarget = PlayerHP.Instance.transform;

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(playerTarget.position);
        agent.speed = data.enemySpeed;
    }
}
