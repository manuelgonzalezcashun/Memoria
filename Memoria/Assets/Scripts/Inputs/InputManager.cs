using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : Singleton<InputManager>
{
    [SerializeField] InputActionAsset inputActions = null;

    private InputAction moveAction = null, interactAction = null, dialogueAction = null;

    public InputAction MoveAction => moveAction;
    public InputAction InteractAction => interactAction;
    public InputAction DialogueAction => dialogueAction;
    void Awake()
    {
        base.Awake();

        moveAction = inputActions["Move"];
        interactAction = inputActions["Interact"];
        dialogueAction = inputActions["Dialogue"];
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
