using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : MonoBehaviour
{
    public float detectionRange = 10f;
    public float chaseSpeed = 7f;
    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
        else if (isChasing && distanceToPlayer > detectionRange * 1.5f)
        {
            isChasing = false;
            // Volver al comportamiento de patrulla
        }
    }
}
