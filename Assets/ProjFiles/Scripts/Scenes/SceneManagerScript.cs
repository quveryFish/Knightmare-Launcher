using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}