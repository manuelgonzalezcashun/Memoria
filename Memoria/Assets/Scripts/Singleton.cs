using UnityEngine;

// * For use whenever creating Singleton Manager scripts
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T Instance => _instance;

    protected void Awake()
    {
        if (_instance == null)
        {
            _instance = gameObject.GetComponent<T>();
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
