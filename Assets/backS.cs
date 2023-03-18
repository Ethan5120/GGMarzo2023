using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backS : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void QuitGame()
    {
        Debug.Log("roberto x quique");
        Application.Quit();
    }
}
