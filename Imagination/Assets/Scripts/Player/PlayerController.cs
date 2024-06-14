using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the Player Movement and any Actions the player will commit
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f, jumpPower = 5f, groundRadius = 0.3f;
    [SerializeField] private LayerMask groundLayerMask;
    private Vector2 groundCheck;
    private bool isGrounded = false;

    private Rigidbody2D playerRB = null;
    private PlayerInput playerInput = null;
    private InputAction moveAction, jumpAction;

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
    }
    void PlayerMove()
    {
        float moveX = moveAction.ReadValue<Vector2>().x;
        playerRB.velocity = new Vector2(moveX * playerSpeed, playerRB.velocity.y);
    }
    void PlayerJump()
    {
        if (isGrounded)
        {
            playerRB.AddForce(new Vector2(playerRB.velocity.x, jumpPower), ForceMode2D.Impulse);
        }
    }

    #region Player Component Binding
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck, groundRadius);
    }
    void InitializePlayer()
    {
        //* Player Components
        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        //* Player Actions
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }
    void AddListeners()
    {
        // TODO Write Code to add all listeners
        // * Player Input Listeners
        jumpAction.performed += ctx => PlayerJump();
    }
    void RemoveListeners()
    {
        // TODO Write code to remove all listeners
        // * Player Input Listeners
        jumpAction.performed -= ctx => PlayerJump();
    }
    #endregion
}
