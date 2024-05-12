using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
   public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log ("Quit");
        Application.Quit();
    }

    private bool pantallaCompleta = true;

    void Start()
    {
        // Agregar un listener al botón para detectar clics
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ToggleModoPantalla);
    }

    void ToggleModoPantalla()
    {
        pantallaCompleta = !pantallaCompleta;

        // Cambiar entre modo pantalla completa y modo ventana
        if (pantallaCompleta)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
        else
        {
            // Aquí puedes definir la resolución deseada para el modo ventana
            int ventanaAncho = 800;
            int ventanaAlto = 600;
            Screen.SetResolution(ventanaAncho, ventanaAlto, false);
        }
    }

}
