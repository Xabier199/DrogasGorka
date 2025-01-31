using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoint : MonoBehaviour
{
    public Transform waypoint; // Referencia al waypoint

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && waypoint != null)
        {
            Debug.Log("Moviendo el objeto al waypoint");
            transform.position = waypoint.position;
            transform.rotation = waypoint.rotation;
        }
    }
}

