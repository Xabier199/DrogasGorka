using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Tiempo que la escena del logo estará visible (en segundos)
    public float logoDuration = 5.0f;

    void Start()
    {
        // Inicia la corrutina para cambiar de escena después del tiempo establecido
        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena()
    {
        // Espera durante el tiempo especificado
        yield return new WaitForSeconds(logoDuration);

        // Cambia a la escena del juego
        SceneManager.LoadScene("Titulopruebas");
    }
}
