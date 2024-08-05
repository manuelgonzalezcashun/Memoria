using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;
public class MenuManager : MonoBehaviour
{
    [SerializeField] SceneReference scene = null;
    public void LoadScene()
    {
        if (SceneManager.GetSceneByName(scene.Name).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            return;
        }

        SceneManager.LoadScene(scene.Name);
    }
}
