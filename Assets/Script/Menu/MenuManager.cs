using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject MenuOpciones;

    void Start()
    {
        // Asegúrate de que al inicio el menú principal esté activo y el de opciones inactivo
        MenuPrincipal.SetActive(true);
        MenuOpciones.SetActive(false);
    }

    public void MostrarOpciones()
    {
        MenuPrincipal.SetActive(false);
        MenuOpciones.SetActive(true);
    }

    public void VolverAlMenuPrincipal()
    {
        MenuPrincipal.SetActive(true);
        MenuOpciones.SetActive(false);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void CargarJuego()
    {
        SceneManager.LoadScene("Cargando");
    }
}


