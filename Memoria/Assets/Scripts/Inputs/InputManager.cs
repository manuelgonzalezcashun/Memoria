using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : Singleton<InputManager>
{
    PlayerInput playerInput = null;

    private InputAction moveAction = null, interactAction = null, dialogueAction = null;
    private const string k_DIALOGUEMAP = "Dialogue";

    public InputAction MoveAction => moveAction;
    public InputAction InteractAction => interactAction;
    public InputAction DialogueAction => dialogueAction;
    void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        interactAction = playerInput.actions["Interact"];
        dialogueAction = playerInput.actions["Dialogue"];

        EventDispatcher.AddListener<ChangeActionMapEvent>(ctx => ChangePlayerActionMap(ctx.newActionMap));
        interactAction.performed += RaiseInteractEvent;
    }

    void OnDisable()
    {
        EventDispatcher.RemoveListener<ChangeActionMapEvent>(ctx => ChangePlayerActionMap(ctx.newActionMap));
        interactAction.performed -= RaiseInteractEvent;
    }
    void ChangePlayerActionMap(string mapName)
    {
        if (playerInput == null) return;

        playerInput.SwitchCurrentActionMap(mapName);
    }
    private void RaiseInteractEvent(InputAction.CallbackContext context)
    {
        PlayerInteractEvent playerInteractEvent = new PlayerInteractEvent();
        EventDispatcher.Raise(playerInteractEvent);
    }
}
