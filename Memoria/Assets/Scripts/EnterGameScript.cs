using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGameScript : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
