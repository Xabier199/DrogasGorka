using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullarCamara : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private float velocidadRotacion; // Añadimos una velocidad de rotación
    private int indiceActual;
    private SpriteRenderer SpriteRenderer;

    private void Start()
    {
        indiceActual = 0;
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Movimiento hacia el punto
        transform.position = Vector3.MoveTowards(transform.position, puntosMovimiento[indiceActual].position, velocidadMovimiento * Time.deltaTime);

        // Rotación hacia el punto solo en el eje Y
        Vector3 direccion = (puntosMovimiento[indiceActual].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * velocidadRotacion);

        if (Vector3.Distance(transform.position, puntosMovimiento[indiceActual].position) < distanciaMinima)
        {
            indiceActual = (indiceActual + 1) % puntosMovimiento.Length;
        }
    }
}




/*private void girar()
   {
       if (transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
       {
           SpriteRenderer.flipX = true;
       }
       else
       {
           SpriteRenderer.flipX = false;
       }
   }*/