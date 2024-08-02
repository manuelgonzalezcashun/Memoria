using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the Player Movement and any Actions the player will commit
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f, interactDist = 0.3f;
    private Rigidbody2D playerRB = null;
    private PlayerInput playerInput = null;
    private InputAction moveAction, interactAction;
    private AnimatorStateMachine player_asm = null;
    private bool stopPlayerMovement = false;

    void Awake()
    {
        InitializePlayer();
    }
    void OnEnable()
    {
        AddListeners();
    }
    void OnDestroy()
    {
        RemoveListeners();
    }
    void FixedUpdate()
    {
        PlayerMove();
    }
    void LateUpdate()
    {
        InteractableManager.Instance.SearchForNearestInteractable(transform.position, interactDist);
        InteractableManager.Instance.PickupInteractable();
    }
    void PlayerMove()
    {
        if (stopPlayerMovement)
        {
            playerRB.velocity = Vector2.zero;
            player_asm.ChangeAnimState("Idle");
            return;
        }

        float moveX = moveAction.ReadValue<Vector2>().x;
        playerRB.velocity = new Vector2(moveX * playerSpeed, playerRB.velocity.y);

        if (moveX != 0)
        {
            player_asm.ChangeAnimState("Run");
        }
        else
        {
            player_asm.ChangeAnimState("Idle");
        }

        Flip(moveX);
    }
    void HandlePlayerInput(bool input)
    {
        gameObject.SetActive(input);
    }
    void HandlePlayerMovement(bool stopMove)
    {
        stopPlayerMovement = stopMove;
        playerInput.enabled = !stopMove;
    }

    void Flip(float velocity) //* Flips the player based on the direction they are heading.
    {
        if (velocity == 0) return;

        transform.localScale = new Vector3(velocity, 1, 1);
    }

    void PlayerInteract() //* Interacts with objects
    {
        player_asm.ChangeAnimState("Collect");
        InteractableManager.Instance.InteractWithObjects();
    }

    #region Player Component Binding
    void InitializePlayer()
    {
        //* Player Components
        playerRB = GetComponent<Rigidbody2D>();
        player_asm = GetComponent<AnimatorStateMachine>();
        playerInput = GetComponent<PlayerInput>();

        //* Player Actions
        moveAction = playerInput.actions["Move"];
        interactAction = playerInput.actions["Interact"];
    }
    void AddListeners()
    {
        // * Player Input Listeners
        interactAction.performed += ctx => PlayerInteract();

        // * Event Listeners
        EventDispatcher.AddListener<LoadSceneEvent>(ctx => HandlePlayerInput(false));
        EventDispatcher.AddListener<PuzzleWinEvent>(ctx => HandlePlayerInput(true));
        EventDispatcher.AddListener<ShowDialogueEvent>(ctx => HandlePlayerMovement(ctx.showDialogueUI));
    }
    void RemoveListeners()
    {
        // * Player Input Listeners
        interactAction.performed -= ctx => PlayerInteract();

        // * Event Listeners
        EventDispatcher.RemoveListener<LoadSceneEvent>(ctx => HandlePlayerInput(false));
        EventDispatcher.RemoveListener<PuzzleWinEvent>(ctx => HandlePlayerInput(true));
        EventDispatcher.AddListener<ShowDialogueEvent>(ctx => HandlePlayerMovement(ctx.showDialogueUI));
    }
    #endregion


}
