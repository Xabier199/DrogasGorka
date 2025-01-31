using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject characterPrefab; // Refencia al prefab del personaje
    public Transform spawnPoint; // Punto de spawneo en la escena

    void Start()
    {
        // Instantiate el personaje en el punto de spawneo
        Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

