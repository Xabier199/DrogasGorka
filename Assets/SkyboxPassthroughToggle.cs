using UnityEngine;
using UnityEngine.UI; // Para usar Toggle

public class SkyboxPassthroughToggle : MonoBehaviour
{
    public Toggle passthroughToggle;         // Referencia al Toggle (Checkbox)
    public Material skyboxMaterial;         // Material del Skybox virtual
    private OVRPassthroughLayer passthroughLayer; // Componente Passthrough Layer
    private Camera mainCamera;              // Cámara principal

    void Start()
    {
        // Obtener la cámara principal
        mainCamera = Camera.main;

        // Obtener el componente OVR Passthrough Layer
        passthroughLayer = mainCamera.GetComponent<OVRPassthroughLayer>();
        if (passthroughLayer == null)
        {
            Debug.LogError("OVRPassthroughLayer no encontrado en la cámara principal.");
            return;
        }

        // Configurar el estado inicial según el Toggle
        UpdateView(passthroughToggle.isOn);

        // Asignar el método para que se ejecute cuando cambie el estado del Toggle
        passthroughToggle.onValueChanged.AddListener(UpdateView);
    }

    // Método para alternar entre Skybox y Passthrough
    public void UpdateView(bool isPassthroughActive)
    {
        if (isPassthroughActive)
        {
            // Activar Passthrough (cámara real)
            passthroughLayer.enabled = true;
            RenderSettings.skybox = null; // Deshabilitar el Skybox
            mainCamera.clearFlags = CameraClearFlags.SolidColor;
        }
        else
        {
            // Activar Skybox (virtual)
            passthroughLayer.enabled = false;
            RenderSettings.skybox = skyboxMaterial; // Establecer el Skybox virtual
            mainCamera.clearFlags = CameraClearFlags.Skybox;
        }
    }
}

