using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Velocidad de movimiento
    public float rotationSpeed = 50.0f; // Velocidad de rotación

    void Update()
    {
        // Movimiento con el joystick izquierdo
        float moveX = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal");
        float moveZ = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);

        // Rotación con el joystick derecho
        float rotateY = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");

        transform.Rotate(0, rotateY * rotationSpeed * Time.deltaTime, 0);
    }
}
