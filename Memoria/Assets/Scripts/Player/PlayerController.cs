using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the Player Movement and any Actions the player will commit
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f, groundRadius = 0.3f, interactDist = 0.3f;
    [SerializeField] private LayerMask groundLayerMask;
    private Vector2 groundCheck;
    private bool isGrounded = false;

    private Rigidbody2D playerRB = null;
    private PlayerInput playerInput = null;
    private InputAction moveAction, interactAction;

    void Awake()
    {
        InitializePlayer();
    }
    void OnEnable()
    {
        AddListeners();
    }
    void OnDisable()
    {
        RemoveListeners();
    }
    void FixedUpdate()
    {
        PlayerMove();
    }
    void LateUpdate()
    {
        groundCheck = new Vector2(transform.position.x, transform.position.y - 1);
        isGrounded = Physics2D.OverlapCircle(groundCheck, groundRadius, groundLayerMask);

        InteractableManager.Instance.SearchForNearestInteractable(transform.position, interactDist);
    }
    void PlayerMove()
    {
        float moveX = moveAction.ReadValue<Vector2>().x;
        playerRB.velocity = new Vector2(moveX * playerSpeed, playerRB.velocity.y);
    }

    void PlayerInteract()
    {
        InteractableManager.Instance.InteractWithObjects();
    }

    #region Player Component Binding
    void InitializePlayer()
    {
        //* Player Components
        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

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
    }
    void RemoveListeners()
    {
        // TODO Write code to remove all listeners
        // * Player Input Listeners
        interactAction.performed -= ctx => PlayerInteract();

        // * Event Listeners
    }
    #endregion
}
