using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacToMainMenu : MonoBehaviour
{
    // vamos a hacer el boton de regreso a la anterior escena.
    public void RegresoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }


}
