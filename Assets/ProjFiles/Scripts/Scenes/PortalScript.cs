using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private Pause_ResumeScript pauseResumeScript;
    [SerializeField] private GameObject endMenu;

    private void OnCollisionEnter(Collision collision)
    {
        pauseResumeScript.PauseGame(endMenu);
    }
}
