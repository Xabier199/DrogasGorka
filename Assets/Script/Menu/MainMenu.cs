using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void EscenaJuego()
    {
        SceneManager.LoadScene("SampleScene");
    
    }

    public void CargarNivel(string nombreNivel) //para poder cargar las opciones.
    {
     SceneManager.LoadScene("Opciones");
    }

    public void Salir() // nos sirve para salir del juego
    {
        Application.Quit(); 
    }

}
