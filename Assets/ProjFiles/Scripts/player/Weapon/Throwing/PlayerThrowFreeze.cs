using UnityEngine;

public class PlayerThrowFreeze : MonoBehaviour
{
    [SerializeField] private GameObject granadePrefab;
    [SerializeField] private Transform throwPoint;
    private float throwForce = 10f;
    public float throwCooldown = 5f;
    private float lastThrowTime;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.deltaTime >= lastThrowTime + throwCooldown)
        {
            ThrowFreezeProjectile();
            lastThrowTime = Time.deltaTime;
        }
    }
    private void ThrowFreezeProjectile()
    {
        GameObject projectile = Instantiate(granadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = throwPoint.forward * throwForce;
        }
    }
}
