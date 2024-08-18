using UnityEngine;

// * Loads new Camera Limits for each scene
public class CameraLimitsLoader : MonoBehaviour
{
    [SerializeField] private float cameraZoom; // * How far camera is from scene
    [SerializeField] private Vector2 _camLimitX = new(); // * Horizontal Limits
    [SerializeField] private Vector2 _camLimitY = new(); // * Vertical Limits


    // * Checks whether camera limits aren't zeros or null
    private bool IsCamLimitAcceptable => _camLimitX != null && _camLimitY != null
        || _camLimitX != Vector2.zero && _camLimitY != Vector2.zero || cameraZoom != 0;

    private void Awake()
    {
        if (!IsCamLimitAcceptable) return;

        EventDispatcher.Raise(new ChangeCameraSettings { newXlimit = _camLimitX, newYLimit = _camLimitY, newCamZoom = cameraZoom });
    }
}
