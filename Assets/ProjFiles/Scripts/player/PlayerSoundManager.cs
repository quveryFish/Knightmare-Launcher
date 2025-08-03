using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public static PlayerSoundManager Instance;

    [SerializeField] private AudioClip PlayerShootAudioClip;
    //public AudioClip PlayerTakeDamageAudioClip;

    public AudioSource AudioSourceShoot;
    public AudioSource AudioSourceGetHurt;
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
        AudioSourceShoot.clip = PlayerShootAudioClip;
    }

}
