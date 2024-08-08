using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : Singleton<InputManager>
{
    [SerializeField] InputActionAsset inputActions = null;

    private InputAction moveAction = null, interactAction = null;

    public InputAction MoveAction => moveAction;
    public InputAction InteractAction => interactAction;
    void Awake()
    {
        base.Awake();

        moveAction = inputActions["Move"];
        interactAction = inputActions["Interact"];
    }
    void OnEnable()
    {
        foreach (var action in inputActions)
        {
            action.Enable();
        }
    }
    void OnDisable()
    {
        foreach (var action in inputActions)
        {
            action.Disable();
        }
    }
}
