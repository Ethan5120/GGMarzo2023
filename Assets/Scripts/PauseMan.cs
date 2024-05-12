using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMan : MonoBehaviour
{
    public void backMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
    }
}
