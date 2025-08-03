using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private int bulletSpeed = 35;
    [SerializeField] private GameObject rocketPref;
    [SerializeField] private Transform rocketSpawnPoint;
    private float timer = 0.6f;
    [SerializeField] private float timeToSet = 0.6f;

    private Vector3 pointToMove;
    private void Start()
    {
        timer = timeToSet;

    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (timer <= 0)
            {
                PlayerSoundManager.Instance.AudioSourceShoot.Play();
                toShoot();
                timer = timeToSet;
            }
        }
    }


    private void toShoot()
    {
        Quaternion rotatedRotation = rocketSpawnPoint.rotation * Quaternion.Euler(0, 90, 0);
        GameObject bullet = Instantiate(rocketPref, rocketSpawnPoint.position, rotatedRotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = rocketSpawnPoint.forward * bulletSpeed;
    }
}
