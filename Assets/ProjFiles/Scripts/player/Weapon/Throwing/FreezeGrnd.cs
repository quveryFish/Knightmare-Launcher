using UnityEngine;

public class FreezeGrnd : MonoBehaviour
{
    [SerializeField] private GameObject freezeGranade;
    [SerializeField] private GameObject freezeRadius;
    [SerializeField] private GameObject explSound;
    //[SerializeField] private float freezeTime = 3f;
    readonly private float timeBeforeExplosion = 0.21f;

    private float timeToDestroyObj = 2f;
    private float timeToDestroyRadius;

    private bool isExploded = false;
    private void Awake()
    {
        freezeRadius.SetActive(false);
        explSound.SetActive(false);
        timeToDestroyRadius = timeBeforeExplosion;
    }
    private void Update()
    {
        timeToDestroyObj -= Time.deltaTime;
        if (timeToDestroyObj - 1 <= timeBeforeExplosion || isExploded)
        {
            freezeRadius.SetActive(true);
            explSound.SetActive(true);
            freezeGranade.SetActive(false);
            timeToDestroyRadius -= Time.deltaTime;

        }
        if (timeToDestroyRadius <= 0)
        {
            freezeRadius.SetActive(false);
        }

        if (timeToDestroyObj <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Торкання гранати до ворога активує заморозку одразу
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyFreeze>())
        {
            isExploded = true;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    //Заморозка ворога при вході в радіус дії гранати
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyFreeze>())
        {
            other.gameObject.GetComponent<EnemyFreeze>().isFrozen = true;
            other.gameObject.GetComponent<EnemyHP>()?.TakeDamage(5);
        }
    }
}