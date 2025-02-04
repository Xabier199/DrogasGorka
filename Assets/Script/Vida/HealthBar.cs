using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject objectToDestroy; // Objeto a destruir cuando la vida llega a cero
    public GameObject healthInterface; // Nuevo campo para controlar la visibilidad de la interfaz
    public GameObject newObjectPrefab; // Prefab del nuevo objeto a crear

    private Transform playerTransform; // Transform del jugador
    private Coroutine hideCoroutine; // Variable para mantener referencia al coroutine activo

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        healthInterface.SetActive(false); // Inicia invisible

        // Encontrar al jugador por el tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // Si se ha encontrado al jugador, hacer que la interfaz de salud mire hacia él
        if (playerTransform != null)
        {
            healthInterface.transform.LookAt(playerTransform);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthSlider.value = currentHealth;

        if (currentHealth == 0 && objectToDestroy != null)
        {
            Debug.Log("Destruyendo el objeto: " + objectToDestroy.name); // Mensaje de depuración
            Destroy(objectToDestroy); // Destruye el objeto asignado

            if (newObjectPrefab != null)
            {
                Instantiate(newObjectPrefab, objectToDestroy.transform.position, objectToDestroy.transform.rotation);
                Debug.Log("Creando un nuevo objeto: " + newObjectPrefab.name); // Mensaje de depuración
            }
        }

        // Detener el coroutine activo antes de iniciar uno nuevo
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        hideCoroutine = StartCoroutine(ShowHealthInterface()); // Muestra la interfaz de vida
    }

    private IEnumerator ShowHealthInterface()
    {
        healthInterface.SetActive(true); // Hacer visible
        yield return new WaitForSeconds(5f); // Esperar 5 segundos
        healthInterface.SetActive(false); // Hacer invisible
    }
}


/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject objectToDestroy; // Objeto a destruir cuando la vida llega a cero
    public GameObject healthInterface; // Nuevo campo para controlar la visibilidad de la interfaz
    public GameObject newObjectPrefab; // Prefab del nuevo objeto a crear

    private Coroutine hideCoroutine; // Variable para mantener referencia al coroutine activo

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        healthInterface.SetActive(false); // Inicia invisible
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthSlider.value = currentHealth;

        if (currentHealth == 0 && objectToDestroy != null)
        {
            Debug.Log("Destruyendo el objeto: " + objectToDestroy.name); // Mensaje de depuración
            Destroy(objectToDestroy); // Destruye el objeto asignado

            if (newObjectPrefab != null)
            {
                Instantiate(newObjectPrefab, objectToDestroy.transform.position, objectToDestroy.transform.rotation);
                Debug.Log("Creando un nuevo objeto: " + newObjectPrefab.name); // Mensaje de depuración
            }
        }

        // Detener el coroutine activo antes de iniciar uno nuevo
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        hideCoroutine = StartCoroutine(ShowHealthInterface()); // Muestra la interfaz de vida
    }

    private IEnumerator ShowHealthInterface()
    {
        healthInterface.SetActive(true); // Hacer visible
        yield return new WaitForSeconds(5f); // Esperar 5 segundos
        healthInterface.SetActive(false); // Hacer invisible
    }
}


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject objectToDestroy; // Objeto a destruir cuando la vida llega a cero
    public GameObject healthInterface; // Nuevo campo para controlar la visibilidad de la interfaz
    public GameObject newObjectPrefab; // Prefab del nuevo objeto a crear

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        healthInterface.SetActive(false); // Inicia invisible
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthSlider.value = currentHealth;

        if (currentHealth == 0 && objectToDestroy != null)
        {
            Debug.Log("Destruyendo el objeto: " + objectToDestroy.name); // Mensaje de depuración
            Destroy(objectToDestroy); // Destruye el objeto asignado

            if (newObjectPrefab != null)
            {
                Instantiate(newObjectPrefab, objectToDestroy.transform.position, objectToDestroy.transform.rotation);
                Debug.Log("Creando un nuevo objeto: " + newObjectPrefab.name); // Mensaje de depuración
            }
        }

        StartCoroutine(ShowHealthInterface()); // Muestra la interfaz de vida
    }

    private IEnumerator ShowHealthInterface()
    {
        healthInterface.SetActive(true); // Hacer visible
        yield return new WaitForSeconds(5f); // Esperar 5 segundos
        healthInterface.SetActive(false); // Hacer invisible
    }
}*/

