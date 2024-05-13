using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;
    [SerializeField] AudioSource menuSong;
   public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log ("Quit");
        Application.Quit();
    }

    //private bool pantallaCompleta = true;

    void Start()
    {
        GM.cGState = GameManagerSO.GameState.MainMenu;
        menuSong.Play();
    }

    /*void ToggleModoPantalla()
    {
        pantallaCompleta = !pantallaCompleta;

        // Cambiar entre modo pantalla completa y modo ventana
        if (pantallaCompleta)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
        else
        {
            // Aqu� puedes definir la resoluci�n deseada para el modo ventana
            int ventanaAncho = 800;
            int ventanaAlto = 600;
            Screen.SetResolution(ventanaAncho, ventanaAlto, false);
        }
    }*/

}
