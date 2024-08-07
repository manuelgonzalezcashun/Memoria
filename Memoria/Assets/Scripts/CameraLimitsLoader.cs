using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimitsLoader : MonoBehaviour
{
    [SerializeField] private Vector2 _camLimitX = new();
    [SerializeField] private Vector2 _camLimitY = new();

    private bool IsCamLimitAcceptable => _camLimitX != null && _camLimitY != null
        || _camLimitX != Vector2.zero && _camLimitY != Vector2.zero;

    private void Awake()
    {
        if (!IsCamLimitAcceptable) return;

        EventDispatcher.Raise(new ChangeCameraSettings { newXlimit = _camLimitX, newYLimit = _camLimitY });
    }
}
