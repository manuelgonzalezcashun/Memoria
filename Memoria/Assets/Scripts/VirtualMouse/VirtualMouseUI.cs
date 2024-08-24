using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;

public class VirtualMouseUI : MonoBehaviour
{

    private VirtualMouseInput virtualMouseInput;

    private void Awake()
    {
        virtualMouseInput = GetComponent<VirtualMouseInput>();
    }

    private void LateUpdate()
    {

        Vector2 virtualMousePosition = virtualMouseInput.virtualMouse.position.value;
        virtualMousePosition.x = Mathf.Clamp(virtualMousePosition.x, -Screen.width, Screen.width);
        virtualMousePosition.y = Mathf.Clamp(virtualMousePosition.y, -Screen.height, Screen.height);
        InputState.Change(virtualMouseInput.virtualMouse.position, virtualMousePosition);

    }
}
