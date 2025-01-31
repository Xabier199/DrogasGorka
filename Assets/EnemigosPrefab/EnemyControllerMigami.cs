using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerMigami : MonoBehaviour
{
    public GameObject GameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRaycastHit()
    {
        Debug.Log("Enemigo destruido");
        Destroy(GameObject);
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
*/