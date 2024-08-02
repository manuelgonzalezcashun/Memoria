using UnityEngine;
public class InputManager : MonoBehaviour
{
    private static InputManager _instance = null;

    public static InputManager Instance => _instance;
    void OnEnable()
    {
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
