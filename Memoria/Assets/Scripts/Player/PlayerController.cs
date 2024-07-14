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
        InteractableManager.Instance.SearchForNearestInteractable(transform.position, interactDist);
        InteractableManager.Instance.PickupInteractable();
    }
    void PlayerMove()
    {
        float moveX = moveAction.ReadValue<Vector2>().x;
        playerRB.velocity = new Vector2(moveX * playerSpeed, playerRB.velocity.y);

        if (moveX != 0)
        {
            EventDispatcher.Raise(new ChangeAnimStateEvent { _state = "Run" });
        }
        else
        {
            EventDispatcher.Raise(new ChangeAnimStateEvent { _state = "Idle" });
        }

        Flip(moveX);
    }

    void Flip(float velocity) //* Flips the player based on the direction they are heading.
    {
        if (velocity == 0) return;

        transform.localScale = new Vector3(velocity, 1, 1);
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
