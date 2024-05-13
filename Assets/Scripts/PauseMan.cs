using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMan : MonoBehaviour
{
    public void backMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
