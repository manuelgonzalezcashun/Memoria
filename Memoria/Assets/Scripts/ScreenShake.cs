using PrimeTween;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Camera _camera;

    [SerializeField][Range(0, 1)] float _shakeStrength = 0; // ? How strong it will shake the camera
    [SerializeField] float _duration = 0; // ? How long the camera will shake for
    [SerializeField] float _frequency = 0; // ? How many shakes it will have

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    void OnEnable()
    {
        EventDispatcher.AddListener<ScreenShakeEvent>(Shake);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<ScreenShakeEvent>(Shake);
    }
    public void Shake(ScreenShakeEvent screenShakeEvent)
    {
        Shake();
    }

    public void Shake()
    {
        Tween.ShakeCamera(_camera, _shakeStrength, _duration, _frequency);
    }
}
