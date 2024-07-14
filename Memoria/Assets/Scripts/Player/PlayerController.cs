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

    void Flip(float velocity) //* Flips the player based on the direction they are heading.
    {
        if (velocity == 0) return;

        transform.localScale = new Vector3(velocity, 1, 1);
    }

    void PlayerInteract() //* Interacts with objects
    {
        InteractableManager.Instance.InteractWithObjects();
    }

    #region Player Component Binding
    void InitializePlayer()
    {
        //* Player Components
        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        player_asm = GetComponent<AnimatorStateMachine>();

        //* Player Actions
        moveAction = playerInput.actions["Move"];
        interactAction = playerInput.actions["Interact"];
    }
    void AddListeners()
    {
        // TODO Write Code to add all listeners
        // * Player Input Listeners
        interactAction.performed += ctx => PlayerInteract();

        // * Event Listeners
        EventDispatcher.AddListener<LoadPuzzleEvent>(ctx => HandlePlayerInput(false));
        EventDispatcher.AddListener<PuzzleWinEvent>(ctx => HandlePlayerInput(true));
    }
    void RemoveListeners()
    {
        // TODO Write code to remove all listeners
        // * Player Input Listeners
        interactAction.performed -= ctx => PlayerInteract();

        // * Event Listeners
        EventDispatcher.RemoveListener<LoadPuzzleEvent>(ctx => HandlePlayerInput(false));
        EventDispatcher.RemoveListener<PuzzleWinEvent>(ctx => HandlePlayerInput(true));
    }
    #endregion


}
