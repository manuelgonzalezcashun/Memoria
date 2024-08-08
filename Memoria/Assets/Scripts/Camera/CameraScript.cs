using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] bool debugMode = false;
    private Camera cameraInstance = null;
    void OnEnable()
    {
        cameraInstance = GetComponent<Camera>();
        if (debugMode) return;

        CameraManager.Instance.Add(cameraInstance);
        CameraManager.Instance.SetCamera(cameraInstance.name);
    }
    void OnDisable()
    {
        if (debugMode) return;
        if (cameraInstance.name == CameraManager.Instance.DefaultCamera) return;

        CameraManager.Instance.SetCamera(CameraManager.Instance.DefaultCamera);
        CameraManager.Instance.Remove(cameraInstance);
    }
}
