using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera cameraInstance = null;
    public Transform targetTransform;
    public Vector3 offset;

    [Range(0, 1)]
    public float smoothTime;

    [Header("Camera Limits")]
    public Vector2 xLimit;
    public Vector2 yLimit;
    public float camZoomValue;
    private Vector3 velocity = Vector3.zero;

    void OnEnable()
    {
        cameraInstance = GetComponent<Camera>();

        EventDispatcher.AddListener<ChangeCameraSettings>(ctx => SetNewCameraLimits(ctx.newXlimit, ctx.newYLimit, ctx.newCamZoom));
    }
    void OnDisable()
    {
        cameraInstance = null;

        EventDispatcher.RemoveListener<ChangeCameraSettings>(ctx => SetNewCameraLimits(ctx.newXlimit, ctx.newYLimit, ctx.newCamZoom));
    }

    void LateUpdate()
    {
        if (targetTransform == null) return; // * Safe Guard from Player Death

        Vector3 targetPosition = targetTransform.position + offset;

        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    void SetNewCameraLimits(Vector2 newXLimit, Vector2 newYLimit, float newCamZoom)
    {
        xLimit = newXLimit;
        yLimit = newYLimit;

        if (cameraInstance == null) return;
        cameraInstance.orthographicSize = newCamZoom;
    }
}
