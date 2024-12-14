using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : Singleton<InputManager>
{
    PlayerInput playerInput = null;

    private InputAction moveAction = null, interactAction = null, dialogueAction = null, pauseAction = null;
    public InputAction MoveAction => moveAction;
    void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        interactAction = playerInput.actions["Interact"];
        dialogueAction = playerInput.actions["Dialogue"];
        pauseAction = playerInput.actions["Pause"];

        EventDispatcher.AddListener<ChangeActionMapEvent>(ChangePlayerActionMap);
        interactAction.performed += RaiseInteractEvent;
        dialogueAction.performed += RaiseDialogueEvent;
        pauseAction.performed += RaisePauseEvent;
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<ChangeActionMapEvent>(ChangePlayerActionMap);

        if (interactAction == null) return;
        interactAction.performed -= RaiseInteractEvent;
        dialogueAction.performed -= RaiseDialogueEvent;
        pauseAction.performed -= RaisePauseEvent;
    }
    void ChangePlayerActionMap(ChangeActionMapEvent evt) => ChangePlayerActionMap(evt.newActionMap);
    void ChangePlayerActionMap(string mapName)
    {
        if (playerInput == null) return;

        playerInput.SwitchCurrentActionMap(mapName);
    }
    private void RaiseInteractEvent(InputAction.CallbackContext context)
    {
        if (interactAction == null) return;

        InteractPressedEvent interact = new InteractPressedEvent();
        EventDispatcher.Raise(interact);
    }
    private void RaiseDialogueEvent(InputAction.CallbackContext context)
    {
        if (dialogueAction == null) return;

        DialoguePressedEvent dialogue = new DialoguePressedEvent();
        EventDispatcher.Raise(dialogue);
    }
    private void RaisePauseEvent(InputAction.CallbackContext context)
    {
        if (pauseAction == null) return;

        GamePausedEvent gamePaused = new GamePausedEvent { isPaused = true };
        EventDispatcher.Raise(gamePaused);
    }
}
