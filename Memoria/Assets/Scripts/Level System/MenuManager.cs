using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;
public class MenuManager : MonoBehaviour
{
    [SerializeField] SceneReference scene = null;
    public void LoadScene()
    {
        if (scene == null)
        {
            Debug.LogWarning($"{name} is missing a scene reference!");
            return;
        }

        SceneManager.LoadScene(scene.Name);
    }
}
