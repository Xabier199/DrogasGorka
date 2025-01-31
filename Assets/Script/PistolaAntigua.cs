using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaAntigua : MonoBehaviour
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

    public int damage = 10; // Cantidad de daño que causa la pistola

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

            // Verificar si el objeto impactado tiene el script HealthBar
            HealthBar healthBar = hit.collider.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                source.PlayOneShot(hitAudioClip);
                healthBar.TakeDamage(damage); // Resta la vida correspondiente
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
using UnityEngine;

public class PistolaAntigua : MonoBehaviour
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
}*/



