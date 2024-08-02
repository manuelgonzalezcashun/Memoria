using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance = null;
    private PlayerInput playerInput;
    private InputAction moveAction = null, interactAction = null;

    public static InputManager Instance => _instance;
    void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();

        SetInstance();
    }

    void OnDisable()
    {

    }

    void SetInstance()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
