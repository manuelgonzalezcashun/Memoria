using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] bool debugMode = false;
    private Camera cameraInstance = null;
    void OnEnable()
    {
        cameraInstance = GetComponent<Camera>();
    }
    void OnDestroy()
    {
        if (debugMode) return;

        CameraManager.Instance.Remove(cameraInstance);
        CameraManager.Instance.SetCamera(CameraManager.Instance.DefaultCamera);
    }
    void Start()
    {
        if (debugMode) return;

        CameraManager.Instance.Add(cameraInstance);
        CameraManager.Instance.SetCamera(cameraInstance.name);
    }
}
