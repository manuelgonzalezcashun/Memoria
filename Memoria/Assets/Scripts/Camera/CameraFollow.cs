using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform targetTransform;
    public Vector3 offset;

    [Range(0, 1)]
    public float smoothTime;

    [Header("Camera Limits")]
    public Vector2 xLimit;
    public Vector2 yLimit;
    private Vector3 velocity = Vector3.zero;

    private void OnEnable()
    {
        EventDispatcher.AddListener<ChangeCameraSettings>(ctx => SetNewCameraLimits(ctx.newXlimit, ctx.newYLimit));
    }
    private void OnDestroy()
    {
        EventDispatcher.RemoveListener<ChangeCameraSettings>(ctx => SetNewCameraLimits(ctx.newXlimit, ctx.newYLimit));
    }

    void LateUpdate()
    {
        if (targetTransform == null) return; // * Safe Guard from Player Death

        Vector3 targetPosition = targetTransform.position + offset;

        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    void SetNewCameraLimits(Vector2 newXLimit, Vector2 newYLimit)
    {
        xLimit = newXLimit;
        yLimit = newYLimit;
    }
}
