using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class raygun : MonoBehaviour
{
    public LayerMask layerMask;
    public OVRInput.RawButton shootingButton;
    public LineRenderer lineprefab;
    public GameObject rayImpactPrefab;
    public Transform shootingpoint;
    public float maxLineDisance = 5;
    public float lineShowTimer = 0.3f;
    public AudioSource source;
    public AudioClip shootingAudioClip;
    public AudioClip hitAudioClip;
    public GameObject shootHitbox;
    public GameObject jugadorayudapofavoh;
    public GameObject playerPrefab; // Prefab del jugador
    public Transform waypoint; // Waypoint para la nueva posición

    void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        source.PlayOneShot(shootingAudioClip);

        Ray ray = new Ray(shootingpoint.position, shootingpoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDisance, layerMask);

        Vector3 endPoint = Vector3.zero;

        if (hasHit)
        {
            endPoint = hit.point;
            Quaternion rayImpactRotation = Quaternion.LookRotation(-hit.normal);
            GameObject rayImpact = Instantiate(rayImpactPrefab, hit.point, rayImpactRotation);
            Destroy(rayImpact, 1);

            // Verificar si el objeto impactado tiene el script EnemyController
            EnemyController enemy = hit.collider.GetComponent<EnemyController>();
            if (enemy != null)
            {
                source.PlayOneShot(hitAudioClip);
                enemy.OnRaycastHit();

                // Instanciar el prefab del jugador en el waypoint
                if (playerPrefab != null && waypoint != null)
                {
                    
                    Debug.Log("Instanciando el prefab del jugador en el waypoint");
                    Instantiate(playerPrefab, waypoint.position, waypoint.rotation);
                    SceneManager.LoadScene("Cargando Combate");
                    GameObject.Destroy(jugadorayudapofavoh);


                }
                else
                {
                    if (playerPrefab == null)
                        Debug.Log("playerPrefab es null");
                    if (waypoint == null)
                        Debug.Log("waypoint es null");
                }
            }
        }
        else
        {
            endPoint = shootingpoint.position + shootingpoint.forward * maxLineDisance;
        }

        LineRenderer line = Instantiate(lineprefab);
        line.positionCount = 2;
        line.SetPosition(0, shootingpoint.position);
        line.SetPosition(1, endPoint);
        Destroy(line.gameObject, lineShowTimer);
    }
}













/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class raygun : MonoBehaviour
{

    public LayerMask layerMask;
    public OVRInput.RawButton shootingButton;
    public LineRenderer lineprefab;
    public GameObject rayImpactPrefab;
    public Transform shootingpoint;
    public float maxLineDisance = 5;
    public float lineShowTimer = 0.3f;
    public AudioSource source;
    public AudioClip shootingAudioClip;
    public GameObject shootHitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            Shoot();
        }
    }

    public void Shoot()
    {

        source.PlayOneShot(shootingAudioClip);
     
        
        


        Ray ray = new Ray(shootingpoint.position, shootingpoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDisance, layerMask);

        Vector3 endPoint = Vector3.zero;


        if (hasHit)
        {
            //stop the ray
            endPoint = hit.point;

            Quaternion rayImpactRotation = Quaternion.LookRotation(-hit.normal);

            GameObject rayImpact = Instantiate(rayImpactPrefab, hit.point, rayImpactRotation);
            Destroy(rayImpact, 1);
        }
        else
        {
            endPoint = shootingpoint.position + shootingpoint.forward * maxLineDisance;
        }
    
        LineRenderer line = Instantiate(lineprefab);
        line.positionCount = 2;
        line.SetPosition(0, shootingpoint.position);

        

        line.SetPosition(1, endPoint);

        Destroy(line.gameObject, lineShowTimer);
    }
}*/
