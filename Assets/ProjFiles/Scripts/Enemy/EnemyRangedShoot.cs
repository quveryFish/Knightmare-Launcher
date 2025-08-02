using UnityEngine;

public class EnemyRangedShoot : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 5;
    [SerializeField] private GameObject rocketPref;
    [SerializeField] private Transform rocketSpawnPoint;
    private float timer = 1.8f;
    private float timeToSet = 1.8f;

    Transform playerTransform;
    private void Start()
    {
        playerTransform = PlayerHP.Instance.transform;
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
        Quaternion rotatedRotation = rocketSpawnPoint.rotation * Quaternion.Euler(0, 90, 0);
        GameObject bullet = Instantiate(rocketPref, rocketSpawnPoint.position, rotatedRotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = (playerTransform.position - rocketSpawnPoint.position).normalized * bulletSpeed;
    }
}
