using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{ 

    private Camera _mainCamera;
    public GameObject canvas4;
    public GameObject camera4;

   private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos:(Vector3)Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        canvas4.SetActive(false);
        camera4.SetActive(false);
    }
}
