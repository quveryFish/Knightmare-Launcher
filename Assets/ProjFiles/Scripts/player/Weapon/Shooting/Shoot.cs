using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static Shoot Instance;

    [SerializeField] private int bulletSpeed = 35;
    [SerializeField] private GameObject rocketPref;
    [SerializeField] private Transform rocketSpawnPoint;

    private float timer;
    [SerializeField] private float timeToSet = 0.6f;

    private int raduisUpgNum = 0;
    private int damage = 10;

    private Vector3 pointToMove;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        timer = timeToSet;

    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
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

    public int AddDamage(int amount)
    {
        damage += amount;
        return damage;
    }
    public int AddRadiusNum()
    {
        raduisUpgNum += 1;
        return raduisUpgNum;
    }
    public int GetRadiusNum()
    {
        return raduisUpgNum;
    }
    public int GetDamage()
    {
        return damage;
    }

    public float SubtractShootingTime(float amount)
    {
        timeToSet -= amount;
        return timeToSet;
    }
}
