using UnityEngine;

public class EnemyRangedShoot : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private int bulletSpeed = 5;
    [SerializeField] private GameObject rocketPref;
    [SerializeField] private Transform rocketSpawnPoint;
    private float timer;
    private float timeToSet;

    private AudioSource audioSource;

    Transform playerTransform;
    private void Start()
    {
        timeToSet = enemyData.AttackSpeed;
        timer = 1;
        playerTransform = PlayerHP.Instance.transform;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            toShoot();
            timer = timeToSet;
        }
    }
    private void toShoot()
    {
        audioSource.Play();
        Quaternion rotatedRotation = rocketSpawnPoint.rotation * Quaternion.Euler(0, 90, 0);
        GameObject bullet = Instantiate(rocketPref, rocketSpawnPoint.position, rotatedRotation, rocketSpawnPoint);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = (playerTransform.position - rocketSpawnPoint.position).normalized * bulletSpeed;
    }
}
