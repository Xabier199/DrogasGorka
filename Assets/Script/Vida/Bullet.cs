using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name); // Mensaje de depuración
        HealthBar healthBar = other.GetComponent<HealthBar>();
        if (healthBar != null)
        {
            healthBar.TakeDamage(damage);
            Destroy(gameObject); // Destruye la bala después de la colisión
        }
    }
}
