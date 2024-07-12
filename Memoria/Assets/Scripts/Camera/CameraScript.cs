using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] bool debugMode = false;
    private Camera cameraInstance = null;
    public Transform targetTransform;
    public Vector3 offset;

    [Range(0, 1)]
    public float smoothTime;

    [Header("Camera Limits")]
    public Vector2 xLimit;
    public Vector2 yLimit;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (!debugMode)
        {
            CameraManager.Instance.Add(cameraInstance);
            CameraManager.Instance.SetCamera(cameraInstance.name);
        }
    }
    void OnEnable()
    {
        cameraInstance = GetComponent<Camera>();
    }
    void OnDestroy()
    {
        if (!debugMode)
        {
            CameraManager.Instance.Remove(cameraInstance);
            CameraManager.Instance.SetCamera(CameraManager.Instance.DefaultCamera);
        }
    }
    void LateUpdate()
    {
        if (targetTransform == null) return; // * Safe Guard from Player Death

        Vector3 targetPosition = targetTransform.position + offset;

        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
