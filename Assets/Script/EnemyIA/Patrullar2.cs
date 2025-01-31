using System.Collections;
using UnityEngine;

public class Patrullar2 : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private float distanciaPersecucion; // Distancia para empezar a seguir al jugador
    [SerializeField] private float distanciaSeguridad; // Distancia mínima para mantener con el jugador
    [SerializeField] private float velocidadRotacion;
    [SerializeField] private string waypointTag = "Waypoint2"; // Etiqueta de los waypoints en la escena, configúralo en el Inspector.
    [SerializeField] private AudioClip sonidoSeguimiento; // Sonido a reproducir al seguir al jugador

    private Transform[] puntosMovimiento;
    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;
    private Transform jugador; // Referencia al jugador
    private bool persiguiendoJugador = false;
    private AudioSource audioSource; // Componente de audio
    private bool sonidoReproducido = false; // Indica si el sonido ya se ha reproducido

    private void Start()
    {
        // Encuentra los waypoints en la escena por tag
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        puntosMovimiento = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            puntosMovimiento[i] = waypointObjects[i].transform;
        }

        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform; // Asume que el jugador tiene el tag "Player" y lo busca en la escena
        audioSource = GetComponent<AudioSource>(); // Obtener el componente de audio
        if (audioSource == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en el enemigo.");
        }
    }

    private void Update()
    {
        if (puntosMovimiento.Length == 0) return; // Evita errores si no hay waypoints asignados

        float distanciaAlJugador = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                                    new Vector3(jugador.position.x, 0, jugador.position.z));
        if (distanciaAlJugador < distanciaPersecucion)
        {
            persiguiendoJugador = true;
            if (!sonidoReproducido)
            {
                audioSource.PlayOneShot(sonidoSeguimiento);
                sonidoReproducido = true; // Marcar el sonido como reproducido
            }
        }
        else if (distanciaAlJugador > distanciaPersecucion)
        {
            persiguiendoJugador = false;
            sonidoReproducido = false; // Reiniciar el indicador de sonido
        }

        if (persiguiendoJugador)
        {
            // Seguir al jugador manteniendo la altura actual del enemigo
            SeguirJugador();
        }
        else
        {
            // Patrullar entre waypoints con alturas ajustadas
            PatrullarWaypoints();
        }
    }

    private void SeguirJugador()
    {
        Vector3 jugadorPosicion = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        float distanciaAlJugador = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                                    new Vector3(jugadorPosicion.x, 0, jugadorPosicion.z)); // Ignora la altura (y)
        if (distanciaAlJugador > distanciaSeguridad)
        {
            // Seguir al jugador si la distancia es mayor que la distancia de seguridad
            transform.position = Vector3.MoveTowards(transform.position, jugadorPosicion, velocidadMovimiento * Time.deltaTime);

            // Rotar para mirar al jugador sin cambiar la altura (y)
            Vector3 direccion = (jugadorPosicion - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);
        }
        else
        {
            // Mantener la rotación mirando al jugador sin cambiar la altura (y)
            Vector3 direccion = (jugadorPosicion - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);
        }
    }

    private void PatrullarWaypoints()
    {
        if (puntosMovimiento.Length == 0) return;  // Evita errores si no hay waypoints asignados

        Vector3 waypointPosicion = puntosMovimiento[numeroAleatorio].position;
        transform.position = Vector3.MoveTowards(transform.position, waypointPosicion, velocidadMovimiento * Time.deltaTime);

        // Rotar hacia el waypoint ajustando la altura (y)
        Vector3 direccion = (waypointPosicion - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);

        if (Vector3.Distance(transform.position, waypointPosicion) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        }
    }
}


/*using System.Collections;
using UnityEngine;

public class Patrullar2 : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private float distanciaPersecucion; // Distancia para empezar a seguir al jugador
    [SerializeField] private float distanciaSeguridad; // Distancia mínima para mantener con el jugador
    [SerializeField] private float velocidadRotacion;
    [SerializeField] private string waypointTag = "Waypoint2"; // Etiqueta de los waypoints en la escena, configúralo en el Inspector.

    private Transform[] puntosMovimiento;
    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;
    private Transform jugador; // Referencia al jugador
    private bool persiguiendoJugador = false;

    private void Start()
    {
        // Encuentra los waypoints en la escena por tag
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        puntosMovimiento = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            puntosMovimiento[i] = waypointObjects[i].transform;
        }

        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform; // Asume que el jugador tiene el tag "Player" y lo busca en la escena
    }

    private void Update()
    {
        if (puntosMovimiento.Length == 0) return; // Evita errores si no hay waypoints asignados

        float distanciaAlJugador = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                                    new Vector3(jugador.position.x, 0, jugador.position.z));
        if (distanciaAlJugador < distanciaPersecucion)
        {
            persiguiendoJugador = true;
        }
        else if (distanciaAlJugador > distanciaPersecucion)
        {
            persiguiendoJugador = false;
        }

        if (persiguiendoJugador)
        {
            // Seguir al jugador manteniendo la altura actual del enemigo
            SeguirJugador();
        }
        else
        {
            // Patrullar entre waypoints con alturas ajustadas
            PatrullarWaypoints();
        }
    }

    private void SeguirJugador()
    {
        Vector3 jugadorPosicion = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        float distanciaAlJugador = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                                    new Vector3(jugadorPosicion.x, 0, jugadorPosicion.z)); // Ignora la altura (y)
        if (distanciaAlJugador > distanciaSeguridad)
        {
            // Seguir al jugador si la distancia es mayor que la distancia de seguridad
            transform.position = Vector3.MoveTowards(transform.position, jugadorPosicion, velocidadMovimiento * Time.deltaTime);

            // Rotar para mirar al jugador sin cambiar la altura (y)
            Vector3 direccion = (jugadorPosicion - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);
        }
        else
        {
            // Mantener la rotación mirando al jugador sin cambiar la altura (y)
            Vector3 direccion = (jugadorPosicion - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);
        }
    }

    private void PatrullarWaypoints()
    {
        if (puntosMovimiento.Length == 0) return;  // Evita errores si no hay waypoints asignados

        Vector3 waypointPosicion = puntosMovimiento[numeroAleatorio].position;
        transform.position = Vector3.MoveTowards(transform.position, waypointPosicion, velocidadMovimiento * Time.deltaTime);

        // Rotar hacia el waypoint ajustando la altura (y)
        Vector3 direccion = (waypointPosicion - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);

        if (Vector3.Distance(transform.position, waypointPosicion) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        }
    }
}*/
